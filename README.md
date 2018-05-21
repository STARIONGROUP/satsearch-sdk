# satsearch-sdk

<img src="https://raw.githubusercontent.com/RHEAGROUP/satsearch-sdk/master/satsearchlogo.png">

A C# library for connecting to the satsearch API available at https://api.satsearch.co. Satsearch provides a search engine for space products & services. This SDK provides a C# abstraction that makes it straightforward to integrate satsearch in your C# project.

# satsearch and CDP4

RHEA Group’s [CDP4](https://github.com/RHEAGROUP/CDP4-IME-Community-Edition) platform offers teams the ability to streamline the engineering process by using the Concurrent Design (CD) methodology. The multidisciplinary nature of preliminary space mission design makes it a suitable environment to deploy the CD methodology. The strengths of the CD process have been exploited by various organizations around the world, including space agencies like [ESA](https://www.esa.int/Our_Activities/Space_Engineering_Technology/CDF) and [NASA](https://jplteamx.jpl.nasa.gov/), and large industry players. One of the key aspects of the CD process is enabling users to rapidly generate and test concepts, necessitating access to a comprehensive library of parts.

<img src="https://github.com/RHEAGROUP/CDP4-SDK-Community-Edition/raw/master/CDP-Community-Edition.png" width="150">

[satsearch’s](https://satsearch.co/) search engine offers users the ability to search through an extensive database of space products and services. With over 5000 products and 700 suppliers available through its platform, satsearch is aiming to build the first global marketplace for space. By brokering supply chain knowledge, satsearch enables users to rapidly navigate the global space supply chain to identify the right products and services.

The [CDP4](https://github.com/RHEAGROUP/CDP4-IME-Community-Edition) satsearch plugin makes use of the **satsearch-sdk** to provide a means to easily make use of the satsearch service. Users can perform searches from within the application and by means of simple drag-n-drop create new elements with parameters in a design. Have a look at this [youtube](https://www.youtube.com/watch?v=4uVmWufaoGw) video to see the result.

# How To

## nuget

The package is available on Nuget at https://www.nuget.org/packages/satsearch-sdk/

[![NuGet Badge](https://buildstats.info/nuget/satsearch-sdk)](https://buildstats.info/nuget/satsearch-skdk)

## Continuous Integration

AppVeyor is used to build and test the satsearch-sdk

Branch | Build Status
------- | :------------
Master |  [![Build status](https://ci.appveyor.com/api/projects/status/1r61oy4gc728gx4d/branch/master?svg=true)](https://ci.appveyor.com/project/samatrhea/satsearch-sdk/branch/master)
Development | [![Build status](https://ci.appveyor.com/api/projects/status/1r61oy4gc728gx4d/branch/development?svg=true)](https://ci.appveyor.com/project/samatrhea/satsearch-sdk/branch/development)

[![Build history](https://buildstats.info/appveyor/chart/samatrhea/satsearch-sdk)](https://ci.appveyor.com/project/samatrhea/satsearch-sdk/history)

## sdk explained

The purpose of the SDK is to enable satsearch in C# projects. The satsearch API provides the means to search for **products** filtering on **categories** and **suppliers**. 

Two tokens are required to access the API:
  - Application Token: A token that can be requested from satsearch to integrate an application with satsearch. This is sent to the service using the **X-APP-ID** HTTP header.
  - API Token: A token that is requested by each end-user that wants to make use of satsearch. An API token can be requested by a user after [registering](https://satsearch.co/register) with satsearch.

The [SatSearchService](https://github.com/RHEAGROUP/satsearch-sdk/blob/master/satsearch-sdk/API/SatSearchService.cs) class is the meat-and-potatoes of the satsearch-SDK. Goto the [wiki](https://github.com/RHEAGROUP/satsearch-sdk/wiki/SatSearchService) for an example on how to use the satsearch-SDK to search for products of specific a supplier and categories.

# License

The libraries contained in the satsearch-SDK are provided to the community under the GNU General Public License. If this license does not suit your needs, feel free to contact us at info@rheagroup.com. We may even grant you a copy of the software with a more liberal license for free.

# Contributions

Contributions to the code-base are welcome. However, before we can accept your contributions we ask any contributor to sign the Contributor License Agreement (CLA) and send this digitaly signed to s.gerene@rheagroup.com. You can find the CLA's in the CLA folder.