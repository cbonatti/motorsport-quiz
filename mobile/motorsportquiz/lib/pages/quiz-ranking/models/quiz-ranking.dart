import 'package:meta/meta.dart';

class QuizRanking {
  int position;
  String name;
  double result;

  QuizRanking(
      {@required this.position, @required this.name, @required this.result});

  factory QuizRanking.fromJson(Map<String, dynamic> json) {
    final QuizRanking quiz = QuizRanking(
      position: int.parse(json['position'].toString()),
      name: json['name'],
      result: double.parse(json['result'].toString()),
    );
    return quiz;
  }
}
