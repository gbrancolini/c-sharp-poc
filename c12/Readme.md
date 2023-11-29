
# C Sharp 12 new feature, benchmark tests
## Primary Constructors
### Property initializators on structs
This new feature not only makes easer to create a property initilized in structs, but also speeds up

| Method                              | Mean    | Error     |StdDev     | Median   | Gen0 |Allocated|
|-------------------------------------|---------|-----------|-----------|---------|--------|---------|
|InitializeDistanceStructLegacyTest   |3.522 μs | 0.1295 μs | 0.3546 μs | 3.394 μs | - | -
|InitializeDistanceInitPropertiesTest |3.210 μs | 0.0639 μs | 0.1683 μs | 3.172 μs | - | -
|InitializeBasicClassLegacy           |77.764 μs| 1.7827 μs | 5.2563 μs | 75.543 μs | 152.9541 | 320001 B
|InitializeBasicClassPrimaryConstructor|81.487 μs| 1.6276 μs | 4.4827 μs | 79.380 μs | 152.9541 | 320000 B

* Mean: Arithmetic mean of all measurements.
* Error: Half of the 99.9% confidence interval
* Median: Value separating the highger half of all measurements (50th percentile)
* Gen0: GC Generation 0 collects per 1000 operations.
* Allocated: Allocated memory per single operation (managed only, inclusive, 1KB = 1024b)
* 1 us: 1 Microsecond (0.000001 sec)

> Written with [StackEdit](https://stackedit.io/).