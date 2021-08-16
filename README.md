# Cosmos Connection Benchmark Testing

## Test different ways of connecting to a cosmos DB

Testing methods:

1) Using DocumentDB (Slow!!)
2) Using EF (Fast but difficult to work with dynamic data)
3) CosmosDB Library

## Important Metrics

1) Time
2) Memory Useage

## How to run the code

### Set up the appropriate connection strings in each file 

1) CosmosLibToCosmos.cs
2) DocumentClientToCosmos.cs
3) EFCoreToCosmos.cs

### Build the application under the Release configuration

### Run Powershell as Admin

1) Navigate to the CosmosTest directory
2) Run the following command:  dotnet run --configuration Release


After following these instructions, you should see benchmark testing in powershell. The DocumentClient takes quite a while for larger data sets. The CosmosLib and EFCore for Cosmos lib are much faster.

## Results

The below results are across one partition and pull around 17000 documents. </br>
*Note: The first time for EF Core took over 4 seconds*


|            Method |     Mean |    Error |   StdDev  |     Gen 0 | Completed Work Items | Lock Contentions | Allocated native memory | Native memory leak |     Gen 1 |     Gen 2 | Allocated |
|------------------ |---------:|---------:|----------:|----------:|---------------------:|-----------------:|------------------------:|-------------------:|----------:|----------:|----------:|
| UseDocumentClient | 18.531 s | 0.3559 s | 0.3329 s  | 7000.0000 |             382.0000 |           1.0000 |                    0 MB |                  - | 2000.0000 |         - |     48 MB |
|      UseCosmosLib |  2.344 s | 0.0452 s | 0.0444 s  | 5000.0000 |              87.0000 |           1.0000 |                    0 MB |                  - | 3000.0000 | 1000.0000 |     33 MB |
|         UseEFCore |  1.598 s | 0.0278 s | 0.0247 s  | 9000.0000 |              51.0000 |                - |                    0 MB |               0 MB | 3000.0000 |         - |     60 MB |


// * Hints *

Outliers

  CosmosRepo.UseDocumentClient: Default -> 1 outlier  was  removed (19.90 s)

  CosmosRepo.UseEFCore: Default         -> 1 outlier  was  removed, 2 outliers were detected (1.55 s, 1.66 s)

|        Term |      Definition |
|------------:|----------------:|
|        Mean             |  Arithmetic mean of all measurements                                                                 |
|       Error             |  Half of 99.9% confidence interval                                                                   |
|      StdDev             |   Standard deviation of all measurements                                                             |
|      Gen 0              | GC Generation 0 collects per 1000 operations                                                         |
| Completed Work Items    | The number of work items that have been processed in ThreadPool (per single operation)               |
| Lock Contentions        | The number of times there was contention upon trying to take a Monitor's lock (per single operation) |
| Allocated native memory | Allocated native memory per single operation                                                         |
| Native memory leak      | Native memory leak size in byte.                                                                     |
| Gen 1                   | GC Generation 1 collects per 1000 operations                                                         |
| Gen 2                   | GC Generation 2 collects per 1000 operations                                                         |
| Allocated               | Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)                         |
                                   
 
