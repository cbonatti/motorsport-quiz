import 'package:meta/meta.dart';

import 'answer.dart';

class Question {
  String id;
  String name;
  List<Answer> answers;

  Question({@required this.id, @required this.name, @required this.answers});
}
