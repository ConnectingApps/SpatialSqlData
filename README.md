# SpatialSqlData

This solution shows how to use spatial data in entity framework core 2.2 as explained [here](https://blogs.msdn.microsoft.com/dotnet/2018/12/04/announcing-entity-framework-core-2-2/). Using the swagger interface, you can add items, get the list of items and also get the closest one given the submitted values.

To get started, make sure you have a recent version of docker and git installed.

```bash
git clone https://github.com/ConnectingApps/SpatialSqlData.git
cd SpatialSqlData
docker-compose build
docker-compose up
```

Visit http://localhost:5982/swagger/