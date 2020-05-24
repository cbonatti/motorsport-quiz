import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { QuizModel } from '../models/quiz.model';
import { Result } from 'src/app/shared/result.model';

@Injectable({
    providedIn: 'root'
})
export class QuizService {

    baseurl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseurl = baseUrl + 'api/quiz';
    }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    GetScores(): Observable<Result<QuizModel[]>> {
        return this.http.get<Result<QuizModel[]>>(this.baseurl + '/scores', this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    errorHandl(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        } else {
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
    }
}