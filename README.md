[![Build status](https://ci.appveyor.com/api/projects/status/p2rek52nkxv93ma8?svg=true)](https://ci.appveyor.com/project/angelovstanton/meissa) [![Join the chat at https://gitter.im/meissarunner/Lobby](https://badges.gitter.im/meissarunner/Lobby.svg)](https://gitter.im/meissarunner/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
![](https://img.shields.io/badge/license-%20Apache--2.0-blue.svg) [![Overview](https://img.shields.io/badge/docs-Overview-green.svg?style=flat)](https://github.com/angelovstanton/Meissa) [![ChangeLog](https://img.shields.io/badge/docs-ChangeLog-green.svg?style=flat)](https://github.com/angelovstanton/Meissa/wiki/Change-Log) [![download](https://img.shields.io/badge/download-1.0.0.0-orange.svg)](https://github.com/angelovstanton/Meissa)

![Meissa Description](https://i.imgur.com/aMVooJy.png)

MEISSA is a distributed tests runner. It is built using the latest technologies such as .NET Core, ASPNET.Core MVC and more. 

It is completely cross-platform able to run tests on Windows, Linux and OSX. 

It is designed to be **programming language agnostic** which means that it can **run tests written on different languages**. 

Right now it can run .NET Framework and .NET Core tests, but it is written in a way that quickly we can add support for Java and other languages and runners.

Features
--------

![MEISSA Features](https://i.imgur.com/MyFQprW.png)

**Parallel on Agents**

The tests execution tremendously speeds up from the distribution on multiple machines. However, it can be further improved by executing the tests in parallel on the tests agents. It can parallelize the tests even in a single container.

**Cross-Platform**

Runs tests on Windows, OSX, and Linux.

**Smart Tests Balancing**

Smartly balances the tests across remote machines based on previous tests execution times which can significantly improve the overall tests runs’ time.

**Failing Tests Retry**

Retries the failing tests multiple times to see whether there are real problems in the system under tests or some random environment issue occurred during the run. In the end, the tool produces single tests results file. You can specify a threshold %. If more than the specified number of tests are failing, they won't be retried. 

**Custom Parameters**

Supports passing custom data to your tests through the runner. Like unique CI build number or some specific folder. You will be able to access the data from your tests through environmental variables.

**Built-in Extendability** 

Executes custom logic without modifying the source code. Offers plug-in API.

**Test Framework and Programming Language Agnostic**

Runs tests written on different test frameworks no matter the language- C#, Java, etc. Offers plug-in API.

**Single CLI** 

Single common command-line interface. No complex installations or configurations.

**Safe Test Run Abortion**

Keeps the clean state of agents and fast test run abortion.

How Do We Use It?
-------------------
1. **Start MEISSA server**
```
meissaserver
```

To coordinate all agents and runners MEISSA has its own server with its own DB.

By the way in order to run MEISSA you don’t even need to install .NET Core since or other dependencies it is completely portable. You just download it as zip, unzip it and that is. Everything you need, runners, agents, servers, DBs is there.

2. **Start MEISSA test agent**
```
meissa testAgent --agentTag="APIAgent" --serverUrl="http://IPServerMachine:89"
```

Usually, you have one test agent per machine. So, more machines you have, faster your tests will be executed.

3. **Start MEISSA tests runner**
```
meissa runner --resultsFilePath="pathToResults\result.trx" 
--agentTag="APIAgent" --testTechnology="MSTest" 
--testLibraryPath="pathToBuildedFiles\SampleTestProj.dll" --serverUrl="http://IPServerMachine:89"
```

Usually, you start the runner from CI job. The typical workflow will be. Download the tests source code. Build it. Execute tests with MEISSA. Publish the results produced by MEISSA.

### Advanced Parameters ###
```
--nativeRunnerArguments="--verbosity="detailed""
``` 

This argument will pass the value to the native tests runner. Here we tell the .NET Core tests runner to produce detailed log.
```
--retriedResultsFilePath="pathToResults\retriedResult.trx" --retriesCount=3 --threshold=90
```

With this one we tell MEISSA to retry the failed tests three times if less than 5% of all tests have failed.
```
--testsFilter="test.FullName != \"TestName\" AND !test.Categories.Contains(\"CI\")"
```

MEISSA has built-in complex test filter parser and we can write complex queries to filter the tests.
```
--customArguments="BuildNumber=42" 
```

Sometimes it is useful to pass data to tests from the runner. For example, you may need to pass the current build number so that you can create a folder in your tests. If you use this argument each agent will create an environmental variable with the name BuildNumber and it will assign the value 42. After that, it is an easy job to get the value from your tests.
```
--timeBasedBalance
```

Instructs MEISSA to balance the tests not based on the count but rather than on the previous execution times of the tests. To use it you need to execute all of your tests at least one time. This is quite useful because some of your UI tests may execute for 1 minute or more but most of them for 30 seconds or less. As I previously mentioned, the whole tests execution time is equal to the slowest sub-run. This feature can sometimes drastically decrease the execution time.
```
--runInParallel
```

Instructs MEISSA to execute in parallel the tests on each agent. You can even specify how many processes to be spawn. This is most useful for unit, API or headless UI tests.
```
--sameMachineByClass
```

The tests from a single class will be executed on the same machine.


Getting Started
---------------

Open CLI and execute
```
dotnet tool install --global meissaserver
```
This will install the MEISSA server as a global tool.
```
dotnet tool install --global meissa
```
This will install the MEISSA agent + runner as a global tool.

To update to the latest version execute:
```
dotnet tool update --global meissaserver
```
```
dotnet tool update --global meissa
```
**Note**: The new update feature is written in a way to preserve the data important for distributing your tests- like previous test execution times.

Get Involved
--------------

- Report bugs 
- Suggest new features 
- Help us write more test runners
- Add more unit tests
- Optimize the performance
- If you have any questions or suggestions you can post them to our **[forum](https://bellatrix.solutions/forums/forums/test/meissa-test-runner/)**.
