# asp.netcore-JsonResourceLocalizer

It is a .Net core 2.0 localization with more than one resource file. It allows you to add localization into your Api with json files as resource files.

Just clone/download and run the project. It shall open Swagger URL like "https://localhost:44340/swagger/index.html" which has below end points. 
1. /api/Localization/{type}/{key}
    Hit this end point with "Info" OR "Warn" OR "Validation" in type field and "Key" in key field. Upon providing "Info", it will return the value for 'Key' from .Info file and Upon providing "Warn", it will return the value for 'Key' from .Warn file and so on.
  Note that Keys are there in Json files.
  
2.   /api/Localization
  This is for data annotation localization
  Check the Model StudentViewModel and its annotations. Check the validation json file for the messages.
  Startup file has below lines to support DataAnnotations localization:
  .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(Validation));
                }
                )
                
                
It supports spanish language also, so you can test for that via postman also. Provide Accept-Language header values as 'es'. You should see the results from .es files.
You can add support to as many languages you want by adding corresponding json files and in Startup.cs file.
