using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.LanguageCore.AWS;
using Japanese.LanguageCore.AWS.Helpers;
using Japanese.Models;
using Microsoft.Extensions.Configuration;
using Nest;

IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);
IConfigurationRoot configurationRoot =  builder.Build(); 

AmazonConfiguration amazonConfiguration = configurationRoot.GetSection("AWS").Get<AmazonConfiguration>();
IAwsService awsService = new AwsService(amazonConfiguration);

DynamoDBHelper dynamoDBHelper = awsService.CreateDynamoDBHelper();
IDynamoDBContext dynamoDbContext = dynamoDBHelper.Context;

ScanOperationConfig scanOperationConfig = new ScanOperationConfig();
Amazon.DynamoDBv2.DataModel.AsyncSearch<Kanjidic2Model> asyncSearch = dynamoDbContext.FromScanAsync<Kanjidic2Model>(scanOperationConfig);
List<Kanjidic2Model> kanjidic2Models = await asyncSearch.GetRemainingAsync();

ConnectionSettings settings = new ConnectionSettings(new Uri("http://localhost:9200"))
            .PrettyJson()
            .DefaultIndex("kanji");

IElasticClient elasticClient = new ElasticClient(settings);

foreach (Kanjidic2Model kanjidic2Model in kanjidic2Models)
{
    await elasticClient.IndexAsync<Kanjidic2Model>(kanjidic2Model, s => s.Id(kanjidic2Model.Literal));
    Console.WriteLine($"Indexed Kanji: {kanjidic2Model.Literal}");
}

Console.WriteLine("...");