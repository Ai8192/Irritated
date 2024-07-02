using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeDrawTime : GradeDraw
{
    public static Grade TimeGrade = Grade.F;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        TimeGrade = GetGrade();
        SetGradeTexture(TimeGrade);
    }

    Grade GetGrade()
    {
        int sec = (int)GameManager.elapsedTime;

        Grade grade = Grade.F;
        switch (GameManager.difficulty)
        {
            case Difficulty.NORMAL:
                // タイムに応じてグレードを与える
                if(sec < 60) // 1:00
                    grade = Grade.A;
                else if(sec < 70) // 1:10
                    grade = Grade.B;
                else if(sec < 85) // 1:25
                    grade = Grade.C;
                else if(sec < 100) // 1:40
                    grade = Grade.D;
                else if(sec < 120) // 2:00
                    grade = Grade.E;

                break;
            case Difficulty.HARD:

                // タイムに応じてグレードを与える
                if (sec < 120) // 2:00
                    grade = Grade.A;
                else if (sec < 135) // 2:15
                    grade = Grade.B;
                else if (sec < 155) // 2:35
                    grade = Grade.C;
                else if (sec < 180) // 3:00
                    grade = Grade.D;
                else if (sec < 210) // 3:30
                    grade = Grade.E;

                break;
            case Difficulty.IRRITATE:

                // タイムに応じてグレードを与える
                if (sec < 270) // 4:30
                    grade = Grade.A;
                else if (sec < 290) // 4:50
                    grade = Grade.B;
                else if (sec < 315) // 5:15
                    grade = Grade.C;
                else if (sec < 345) // 5:45
                    grade = Grade.D;
                else if (sec < 380) // 6:20
                    grade = Grade.E;

                break;
        }

        return grade;
    }
}
