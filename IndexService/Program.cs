﻿using Microsoft.Extensions.Configuration;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;

public class Program
{
    private static string BLOB_URL = "";
    private static string SEARCH_ENDPOINT = "";
    private static string SEARCH_KEY = "";
    private static string SEARCH_INDEX_NAME = "";

    static async Task Main(string[] args)
    {
        ReadConfigFile();

        Uri searchEndpointUri = new(SEARCH_ENDPOINT);

        SearchClient client = new(
            searchEndpointUri,
            SEARCH_INDEX_NAME,
            new AzureKeyCredential(SEARCH_KEY));

        SearchIndexClient clientIndex = new(
            searchEndpointUri,
            new AzureKeyCredential(SEARCH_KEY));

        await CreateIndexAsync(clientIndex);
        await UploadDataAsync(client);
    }

    static void ReadConfigFile()
    {
        string rootPath = Directory.GetCurrentDirectory();
        string configFilePath = Path.Combine(rootPath, "..", "..", "..", "appsettings.json");

        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile(configFilePath, optional: true, reloadOnChange: true)
            .Build();

        BLOB_URL = config["BLOB_URL"];
        SEARCH_ENDPOINT = config["SEARCH_ENDPOINT"];
        SEARCH_KEY = config["SEARCH_KEY"];
        SEARCH_INDEX_NAME = config["SEARCH_INDEX_NAME"];
    }

    static async Task CreateIndexAsync(SearchIndexClient clientIndex)
    {
        Console.WriteLine("Creating search index");
        SearchIndex index = new DocumentSearchIndex(SEARCH_INDEX_NAME);
        var result = await clientIndex.CreateOrUpdateIndexAsync(index);

        Console.WriteLine(result);
    }

    static async Task UploadDataAsync(SearchClient client)
    {
        using HttpClient httpClient = new();

        Console.WriteLine("Downloading TSV data");
        var tsv = await httpClient.GetStringAsync(BLOB_URL);

        Console.WriteLine("Reading and parsing TSV data");
        var documents = new List<DocumentModel>();

        using (var reader = new StringReader(tsv))
        {
            string? line;

            reader.ReadLine();

            while ((line = reader.ReadLine()) != null)
            {
                var values = line.Split('\t');

                var obj = new DocumentModel
                {
                    book_id = values[0],
                    isbn = values[1],
                    authors = values[2].Split(','),
                    publication_year = values[3],
                    title = values[4].Replace("\"", ""),
                    language_code = values[5],
                    average_rating = double.Parse(values[6]),
                };
 
                documents.Add(obj);
            }
        }

        Console.WriteLine("Uploading documents");
        _ = await client.UploadDocumentsAsync(documents);

        Console.WriteLine("Done");
    }
}
