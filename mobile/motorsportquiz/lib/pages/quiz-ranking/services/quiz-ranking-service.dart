import 'dart:convert';
import 'package:motorsportquiz/shared/globals.dart' as globals;
import 'package:http/http.dart' as http;
import 'package:http/http.dart';
import 'package:motorsportquiz/pages/quiz-ranking/models/quiz-ranking.dart';

class QuizRankingService {
  final String url = "${globals.serviceUrl}quiz/scores";

  Future<List<QuizRanking>> getRanking() async {
    Response res = await http.get(url);
    if (res.statusCode == 200) {
      List<dynamic> body = jsonDecode(res.body)['value'];
      List<QuizRanking> ranking = body
          .map(
            (dynamic item) => QuizRanking.fromJson(item),
          )
          .toList();
      return ranking;
    } else {
      throw 'Erro ao carregar ranking';
    }
  }
}
