import 'dart:io';
import 'shared/globals.dart' as globals;
import 'package:flutter/material.dart';

import 'pages/quiz-ranking/quiz-ranking-page.dart';

void main() {
  HttpOverrides.global = new MyHttpOverrides();
  runApp(App());
}

class MyHttpOverrides extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext context) {
    return super.createHttpClient(context)
      ..badCertificateCallback =
          (X509Certificate cert, String host, int port) => true;
  }
}

class App extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    if (Theme.of(context).platform == TargetPlatform.android)
      globals.serviceUrl = 'https://10.0.2.2:5001/api/';
    return MaterialApp(
      title: 'Motorsport Quiz',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        primarySwatch: Colors.indigo,
        visualDensity: VisualDensity.adaptivePlatformDensity,
      ),
      home: QuizRankingPage(),
    );
  }
}
