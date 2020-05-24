import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Result } from 'src/app/shared/result.model';
import { QuestionModel } from '../models/question.model';

@Injectable({
    providedIn: 'root'
})
export class QuestionService {

    baseurl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseurl = baseUrl + 'api/question';
    }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    }

    GetQuestions(): Observable<Result<QuestionModel[]>> {
        return this.http.get<Result<QuestionModel[]>>(this.baseurl, this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    GetQuestion(id): Observable<Result<QuestionModel>> {
        return this.http.get<Result<QuestionModel>>(this.baseurl + '/' + id, this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    Add(answer: QuestionModel): Observable<Result<QuestionModel>> {
        return this.http.post<Result<QuestionModel>>(this.baseurl, JSON.stringify(answer), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    Update(answer: QuestionModel): Observable<Result<QuestionModel>> {
        const command = { id: answer.id, name: answer.name };
        return this.http.put<Result<QuestionModel>>(this.baseurl, JSON.stringify(answer), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandl)
            )
    }

    Delete(id) {
        return this.http.delete<Result<QuestionModel>>(this.baseurl + '/' + id, this.httpOptions)
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