using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalGradeDraw : GradeDraw
{
    public static Grade TotalGrade = Grade.F;

    bool setGrade = false;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if(!setGrade)
        {
            TotalGrade = GetGrade();
            SetGradeTexture(TotalGrade);
            setGrade = true;
        }
    }

    Grade GetGrade()
    {
        Grade grade = Grade.F;
        int gradeValue = (int)GradeDrawTime.TimeGrade + (int)GradeDrawDiamond.DiamondGrade + (int)GradeDrawLife.LifeGrade;

        if (gradeValue < (int)Grade.B * 3)
            grade = Grade.A;
        else if (gradeValue < (int)Grade.C * 3)
            grade = Grade.B;
        else if (gradeValue < (int)Grade.D * 3)
            grade = Grade.C;
        else if (gradeValue < (int)Grade.E * 3)
            grade = Grade.D;
        else if (gradeValue < (int)Grade.F * 3)
            grade = Grade.E;

        return grade;
    }
}