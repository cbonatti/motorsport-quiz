import 'package:meta/meta.dart';

import 'answer.dart';

class Question {
  String id;
  String name;
  List<Answer> answers;

  Question({@required this.id, @required this.name, @required this.answers});

  factory Question.fromJson(Map<String, dynamic> json) {
    final List<dynamic> list = json['answers']
        .map(
          (dynamic item) => Answer.fromJson(item),
        )
        .toList();

    List<Answer> answers = [];
    for (var item in list) {
      answers.add(item);
    }

    return Question(
      id: json['id'].toString(),
      name: json['name'],
      answers: answers,
    );
  }
}
