- Stored data set in MongoDB
    e.g. mongoimport -d test -c items itamcojson2016.json


- NodeJS, Express modules to read data from MongoDB and expose the data using REST API.


- Integrated REST API as part of DOME workflow, where the DOME reads the data from REST API 
and then stages the output for next step.


- POC for DOME which extends DOME's functionality to pass the processed data to next stage using JSON format.
    Modified code in repository to add plugin to read and process JSON data.
    Files added/modified in DOME repository
        DomeInit.java
        db/DbConstants.java
        db/DbErrors.java
        db/DbInit.java
        db/DbUtils.java
        jsonBatch/AbstractJsonBatchModelRuntime.java
        jsonBatch/jsonNameValue/JsonNameValueConfiguration.java
        jsonBatch/jsonNameValue/JsonNameValueModelRuntime.java


- Built 2D holographic/UWP apps using .NET.


- We connected to a Wcf service to get data from another system (an ERP) and to a rest service which crunched the provided MTConnect data.


- We added interactive charts which let the user drill into see detail data and open other apps.


- We also loaded my phone with a similar app to show data specific to a machine.