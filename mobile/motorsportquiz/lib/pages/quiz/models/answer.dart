import 'package:meta/meta.dart';

class Answer {
  String id;
  String name;

  Answer({@required this.id, @required this.name});

  factory Answer.fromJson(Map<String, dynamic> json) {
    return Answer(id: json['id'].toString(), name: json['name'].toString());
  }
}
