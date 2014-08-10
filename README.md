GenericRestService
==================

A generic rest service written in Asp.Net Web API. 

Idea is simple.

A Basic controller which maps to: <hostname>/api/{resource}/{id}.

To Get All Items for a resource:

GET <hostname>/api/{resource}/

To Get a Specific Item

GET <hostname>/api/{resource}/{id}

To Delete an Item

DELETE <hostname>/api/{resource}/{id}

To Create an Item

POST/PUT <hostname>/api/{resource}/ with the JSON Document as the Body

To Update an Item

POST/PUT <hostname>/api/{resource}/{id} with the updated JSON Document as the Body

I wrote this as I needed a generic service to work against for a Mobile App while I was waiting for a 3rd Party to complete their service

To use yourself, just change the connection string, and deploy.
