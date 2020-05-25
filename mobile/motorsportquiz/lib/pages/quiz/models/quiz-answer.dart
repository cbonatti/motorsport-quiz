import 'package:flutter/material.dart';

class QuizAnswer {
  String questionId;
  String answerId;

  QuizAnswer({@required this.questionId, @required this.answerId});

  Map<String, dynamic> toJson() {
    return {"questionId": questionId, "answerId": answerId};
  }

  static List encondeToJson(List<QuizAnswer> list) {
    List jsonList = List();
    list.map((item) => jsonList.add(item.toJson())).toList();
    return jsonList;
  }
}
