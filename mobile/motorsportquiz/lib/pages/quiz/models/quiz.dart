import 'package:meta/meta.dart';
import 'package:motorsportquiz/pages/quiz/models/question.dart';

class Quiz {
  String name;
  List<Question> questions;

  Quiz({@required this.name, @required this.questions});
}
