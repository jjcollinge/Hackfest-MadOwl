TO GET A LIST OF CLASSROOMS AVAILABLE
=====================================
GET http://clustername:8786/api/ClassRoom

HTTP/1.1 200 OK
Content-Length: 15
Content-Type: application/json; charset=utf-8
Server: Microsoft-HTTPAPI/2.0
Date: Wed, 08 Jun 2016 14:40:32 GMT

["classroom19"]

TO GET DATA FOR A SINGLE CLASSROOM
==================================
GET http://clustername:8786/api/ClassRoom?classname=classroom19

HTTP/1.1 200 OK
Content-Length: 186
Content-Type: application/json; charset=utf-8
Server: Microsoft-HTTPAPI/2.0
Date: Wed, 08 Jun 2016 14:39:52 GMT

{"Id":"classroom19","NumSteps":10,"Presenter":"Jonathan","Students":[{"Username":"William","CurrentStep":5},{"Username":"Jamie","CurrentStep":3},{"Username":"Jonathan","CurrentStep":4}]}

If the classroom does not exist, you will get a 404 returned.


UPDATE THE DATA FOR A SINGLE CLASSROOM
======================================
with a JSON payload to update the data for a single classroom

POST http://clustername:8786/api/ClassRoom 

{ 
"Id": "classroom19",
"NumSteps": 10,
"Presenter": "Jonathan",
"Students":[{"Username":"William","CurrentStep":5},{"Username":"Jamie","CurrentStep":3},{"Username":"Jonathan","CurrentStep":4}]}
}

Response should be a 204 no content. 

UPDATE THE DATA FOR A SINGLE STUDENT
====================================

GET http://clustername:8786/api/ClassRoom?classname=classroom19&StudentName=William&newStep=9

{ 
"Id": "classroom19",
"NumSteps": 10,
"Presenter": "Jonathan",
"Students":[{"Username":"William","CurrentStep":9},{"Username":"Jamie","CurrentStep":3},{"Username":"Jonathan","CurrentStep":4}]}
}

Response will be an updated classroom status
