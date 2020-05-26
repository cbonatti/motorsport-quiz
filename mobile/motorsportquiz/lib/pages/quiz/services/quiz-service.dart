import 'dart:convert';
import 'package:motorsportquiz/shared/globals.dart' as globals;
import 'package:http/http.dart' as http;
import 'package:http/http.dart';
import 'package:motorsportquiz/pages/quiz-ranking/models/quiz-ranking.dart';
import 'package:motorsportquiz/pages/quiz/models/question.dart';
import 'package:motorsportquiz/pages/quiz/models/quiz-answer.dart';

class QuizService {
  final String url = globals.serviceUrl;

  Future<List<Question>> start(String userName) async {
    Response res = await http.post(
      '${url}quiz/start',
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(<String, String>{
        'userName': userName,
      }),
    );
    if (res.statusCode == 200) {
      List<dynamic> body = jsonDecode(res.body)['value']['questions'];
      List<Question> questions = body
          .map(
            (dynamic item) => Question.fromJson(item),
          )
          .toList();
      return questions;
    } else {
      throw 'Erro ao iniciar quiz';
    }
  }

  Future<QuizRanking> finish(String userName, List<QuizAnswer> answers) async {
    Response res = await http.post(
      '$url/quiz/finish',
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode({
        'userName': userName,
        'answers': QuizAnswer.encondeToJson(answers),
      }),
    );
    if (res.statusCode == 200) {
      dynamic body = jsonDecode(res.body)['value'];
      return QuizRanking.fromJson(body);
    } else {
      throw 'Erro ao finalizar quiz';
    }
  }
}
