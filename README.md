# Suggester with Azure AI Search Service

<!-- vscode-markdown-toc -->
* [What's Suggester?](#WhatsSuggester)
* [Suggester Scenario](#SuggesterScenario)
	* [Autocomplete](#Autocomplete)
	* [Suggestion](#Suggestion)
* [Demo Setup](#DemoSetup)
* [Reference](#Reference)

<!-- vscode-markdown-toc-config
	numbering=false
	autoSave=true
	/vscode-markdown-toc-config -->
<!-- /vscode-markdown-toc -->

## <a name='WhatsSuggester'></a>What's Suggester?

Azure AI Search service provides Suggester to support autocomplete and suggestion demand. After adding an index in Azure AI Search service, we can create a Suggester and specify its source fields which are used to automatically complete search terms and offer suggested result. Finally we just upload the data which matches the index schema for further testing.

## <a name='SuggesterScenario'></a>Suggester Scenario

### <a name='Autocomplete'></a>Autocomplete
![](./image/demo-autocomplete.gif)

### <a name='Suggestion'></a>Suggestion
![](./image/demo-suggestion.gif)

## <a name='DemoSetup'></a>Demo Setup

1. Create an Azure AI Search service
![](./image/aisearch-setup-1.png)

1. Set the values in appsettings.json
    - SEARCH_ENDPOINT
    ![](./image/aisearch-setup-2.png)

    - SEARCH_KEY
    ![](./image/aisearch-setup-3.png)

1. Open IndexService.sln in Visual Studio 2022
1. In Solution Explorer, right click Solution and run the following steps in order
	- Clean Solution
	- Restore Nuget Packages
	- Build Solution
1. Start Debugging IndexService
1. Check the added index and suggester
    - Index
    ![](./image/aisearch-setup-4.png)

    - Suggester
    ![](./image/aisearch-setup-5.png)

## <a name='Reference'></a>Reference

- [Configure a suggester for autocomplete and suggested matches in a query](https://learn.microsoft.com/en-us/azure/search/index-add-suggesters)
- [Azure AI Search service API documents](https://learn.microsoft.com/en-us/rest/api/searchservice/documents?view=rest-searchservice-2024-05-01-preview)
