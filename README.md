# CosmosTest
Test different ways of connecting to a cosmos DB

|            Method |     Mean |    Error |   StdDev |     Gen 0 | Completed Work Items | Lock Contentions | Allocated native memory | Native memory leak |     Gen 1 |     Gen 2 | Allocated |

|------------------ |---------:|---------:|---------:|----------:|---------------------:|-----------------:|------------------------:|-------------------:|----------:|----------:|----------:|

| UseDocumentClient | 18.531 s | 0.3559 s | 0.3329 s | 7000.0000 |             382.0000 |           1.0000 |                    0 MB |                  - | 2000.0000 |         - |     48 MB |

|      UseCosmosLib |  2.344 s | 0.0452 s | 0.0444 s | 5000.0000 |              87.0000 |           1.0000 |                    0 MB |                  - | 3000.0000 | 1000.0000 |     33 MB |

|         UseEFCore |  1.598 s | 0.0278 s | 0.0247 s | 9000.0000 |              51.0000 |                - |                    0 MB |               0 MB | 3000.0000 |         - |     60 MB |

 

// * Hints *

Outliers

  CosmosRepo.UseDocumentClient: Default -> 1 outlier  was  removed (19.90 s)

  CosmosRepo.UseEFCore: Default         -> 1 outlier  was  removed, 2 outliers were detected (1.55 s, 1.66 s)

 

// * Legends *

  Mean                    : Arithmetic mean of all measurements

  Error                   : Half of 99.9% confidence interval

  StdDev                  : Standard deviation of all measurements

  Gen 0                   : GC Generation 0 collects per 1000 operations

  Completed Work Items    : The number of work items that have been processed in ThreadPool (per single operation)

 Lock Contentions        : The number of times there was contention upon trying to take a Monitor's lock (per single operation)

  Allocated native memory : Allocated native memory per single operation

  Native memory leak      : Native memory leak size in byte.

  Gen 1                   : GC Generation 1 collects per 1000 operations

  Gen 2                   : GC Generation 2 collects per 1000 operations

  Allocated               : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

  1 s                     : 1 Second (1 sec)