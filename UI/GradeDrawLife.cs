using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeDrawLife : GradeDraw
{
    public static Grade LifeGrade = Grade.F;

    protected override void Start()
    {
        base.Start();

        LifeGrade = GetGrade();
        SetGradeTexture(LifeGrade);
    }

    Grade GetGrade()
    {
        int life = GameManager.playerHealth;

        Grade grade = Grade.F;

        if (life >= 70)
            grade = Grade.A;
        else if (life >= 60)
            grade = Grade.B;
        else if (life >= 50)
            grade = Grade.C;
        else if (life >= 40)
            grade = Grade.D;
        else if (life >= 25)
            grade = Grade.E;

        return grade;
    }
}