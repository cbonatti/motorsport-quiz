import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { QuestionComponent } from './question/question.component';
import { AnswerComponent } from './answer/answer.component';
import { QuizService } from './home/services/quiz.service';
import { QuestionService } from './question/services/question.service';
import { AnswerService } from './answer/services/answer.service';
import { AnswerDetailComponent } from './answer/answer-datail.component';
import { QuestionDetailComponent } from './question/question-datail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    QuestionComponent,
    QuestionDetailComponent,
    AnswerComponent,
    AnswerDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'questions', component: QuestionComponent },
      { path: 'question', component: QuestionDetailComponent },
      { path: 'question/:id', component: QuestionDetailComponent },
      { path: 'answers', component: AnswerComponent },
      { path: 'answer', component: AnswerDetailComponent },
      { path: 'answer/:id', component: AnswerDetailComponent },
    ])
  ],
  providers: [QuizService, QuestionService, AnswerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
