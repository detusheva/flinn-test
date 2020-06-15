# Flinndal test app
----

This repo consists out of two parts:

1) import-app-flin
2) Flin-test

## Import app

This app will take a json file as a input argument, parse those records and upload them into the database.

## Flinn test

This is a simple RESTful API that exposes the following routes

* GET /api/products
* GET /api/products/{id}
* POST /api/products
* PUT /api/products/{id}
* DELETE /api/products/{id}

## Development

To debug and test locally, copy the properties/launchSettings.dist.json to properties/launchSettings.json and replace the value "REPLACEME" with a proper connection string.
