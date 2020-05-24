import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Result } from 'src/app/shared/result.model';
import { AnswerModel } from '../models/answer.model';

@Injectable({
    providedIn: 'root'
})
export class AnswerService {

    baseurl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseurl = baseUrl + 'api/answer';
    }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    GetAnswers(): Observable<Result<AnswerModel[]>> {
        return this.http.get<Result<AnswerModel[]>>(this.baseurl, this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    GetAnswer(id): Observable<Result<AnswerModel>> {
        return this.http.get<Result<AnswerModel>>(this.baseurl + '/' + id, this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    Add(answer: AnswerModel): Observable<Result<AnswerModel>> {
        const command = { name: answer.name };
        return this.http.post<Result<AnswerModel>>(this.baseurl, JSON.stringify(command), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    Update(answer: AnswerModel): Observable<Result<AnswerModel>> {
        const command = { id: answer.id, name: answer.name };
        return this.http.put<Result<AnswerModel>>(this.baseurl, JSON.stringify(command), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    Delete(id) {
        return this.http.delete<Result<AnswerModel>>(this.baseurl + '/' + id, this.httpOptions)
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