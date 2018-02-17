[![Build status](https://ci.appveyor.com/api/projects/status/p2rek52nkxv93ma8?svg=true)](https://ci.appveyor.com/project/angelovstanton/meissa) [![Join the chat at https://gitter.im/meissarunner/Lobby](https://badges.gitter.im/meissarunner/Lobby.svg)](https://gitter.im/meissarunner/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
![](https://img.shields.io/badge/license-%20Apache--2.0-blue.svg) [![Overview](https://img.shields.io/badge/docs-Overview-green.svg?style=flat)](https://github.com/angelovstanton/Meissa) [![ChangeLog](https://img.shields.io/badge/docs-ChangeLog-green.svg?style=flat)](https://github.com/angelovstanton/Meissa/wiki/Change-Log) [![download](https://img.shields.io/badge/download-0.1-orange.svg)](https://github.com/angelovstanton/Meissa)

![Meissa Description](https://i.imgur.com/aMVooJy.png)

Meissa is a distributed tests runner. It is built using the latest technologies such as .NET Core, ASPNET.Core MVC and more. 

It is completely cross-platform able to run tests on Windows, Linux and MacOS. 

It is designed to be **programming language agnostic** which means that it can **run tests written on different languages**. 

Right now it can run .NET Framework and .NET Core tests, but it is written in a way that quickly we can add support for Java and other languages and runners.

Features
--------

![Meissa Features](https://i.imgur.com/MyFQprW.png)

- Can run tests on multiple machines using tests agents modes- coordinates the whole process and produce single results file. 
- Can run tests in parallel on every machine using all of the cores of the device. Meissa can parallelize the tests even in a single container.
 - Can retry failing tests multiple times to make sure that there is a real problem in the SUT. 
- The tests can be smartly balanced across remote machines based on previous tests execution times which can significantly improve the overall tests runs’ time.
- A dead simple way of using the tool. It is a single CLI executable. You just run it with different parameters. It is similar to the Selenium Grid.
- Keeping the clean state of agents and fast test run abortion.
- many more

How Do We Use It?
-------------------
1. **Start Meissa server**
```
meissa.exe initServer
```

To coordinate all agents and runners Meissa has its own server with its own DB.

By the way in order to run Meissa you don’t even need to install .NET Core since or other dependencies it is completely portable. You just download it as zip, unzip it and that is. Everything you need, runners, agents, servers, DBs is there.

2. **Start Meissa test agent**
```
meissa.exe testAgent --testAgentTag="APIAgent" --testServerUrl="http://IPServerMachine:5000"
```

Usually, you have one test agent per machine. So, more machines you have, faster your tests will be executed.

3. **Start Meissa tests runner**
```
meissa.exe runner --resultsFilePath="pathToResults\result.trx" --outputFilesLocation="pathToBuildedFiles" --agentTag="APIAgent" 
--testTechnology="MSTestCore" --testLibraryPath="pathToBuildedFiles\SampleTestProj.dll"
```

Usually, you start the runner from CI job. The typical workflow will be. Download the tests source code. Build it. Execute tests with Meissa. Publish the results produced by Meissa.

### Advanced Parameters ###
```
--nativeRunnerArguments="--verbosity="detailed""
``` 

This argument will pass the value to the native tests runner. Here we tell the .NET Core tests runner to produce detailed log.
```
--retriedResultsFilePath="pathToResults\retriedResult.trx" --retriesCount=3 --threshold=90
```

With this one we tell Meissa to retry the failed tests three times if less than 5% of all tests have failed.
```
--testsFilter="test.FullName != \"TestName\" AND !test.Categories.Contains(\"CI\")"
```

Meissa has built-in complex test filter parser and we can write complex queries to filter the tests.
```
--customArguments="BuildNumber=42" 
```

Sometimes it is useful to pass data to tests from the runner. For example, you may need to pass the current build number so that you can create a folder in your tests. If you use this argument each agent will create an environmental variable with the name BuildNumber and it will assign the value 42. After that, it is an easy job to get the value from your tests.
```
--timeBasedBalance
```

Instructs Meissa to balance the tests not based on the count but rather than on the previous execution times of the tests. To use it you need to execute all of your tests at least one time. This is quite useful because some of your UI tests may execute for 1 minute or more but most of them for 30 seconds or less. As I previously mentioned, the whole tests execution time is equal to the slowest sub-run. This feature can sometimes drastically decrease the execution time.
```
--runInParallel
```

Instructs Meissa to execute in parallel the tests on each agent. You can even specify how many processes to be spawn. This is most useful for unit, API or headless UI tests.


Getting Started
---------------

1. Go to meissarunner.com
2. Download
3. Unzip
4. Start executing
5. Check the documentation

Get Involved
--------------

- Report bugs 
- Suggest new features 
- Help us write more test runners
- Add more unit tests
- Optimize the performance
- Go to Gitter and send us a message
