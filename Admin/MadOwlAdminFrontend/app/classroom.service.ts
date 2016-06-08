import { CLASSROOMS } from './mock-classrooms';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
// import { Jsonp } from '@angular/http';
import { Classroom } from './classroom';


@Injectable()
export class ClassroomService {

    constructor(private http: Http) { }
    // constructor(private jsonp: Jsonp) {}

    private classroomsUrl = 'http://localhost:50706/api/Classroom';  // URL to web API

    getClassrooms(): Observable<Classroom> {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'application/json');

        let requestOptions = new RequestOptions( {
            method: RequestMethod.Get,
            url: this.classroomsUrl,
            headers: headers
        });

        return this.http
                    .get(this.classroomsUrl, requestOptions)
                    .map(this.extractData)
                    .catch(this.handleError);

        // let response = this.jsonp.get(this.classroomsUrl);

        // return this.jsonp
        //        .get(this.classroomsUrl)
        //        .map(this.extractData);

        // return this.http.get(this.heroesUrl, {"method": "GET"} )
        //                 .map(this.extractData)
        //                 .catch(this.handleError);


    }

    private extractData(res: Response) {
        let body = res.json();
        return body || { };
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

    getClassroom(id: number) {
        // hardcoded to use the first classroom
        return Promise.resolve(CLASSROOMS).then(
            classrooms => classrooms[0]
        );
    }

}