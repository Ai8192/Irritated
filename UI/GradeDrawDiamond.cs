using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeDrawDiamond : GradeDraw
{
    public static Grade DiamondGrade = Grade.F;

    protected override void Start()
    {
        base.Start();

        DiamondGrade = GetGrade();
        SetGradeTexture(DiamondGrade);
    }

    Grade GetGrade()
    {
        float ratio = (float)GameManager.diamond / DiamondCounter.amount_of_diamond;

        Grade grade = Grade.F;

        // ƒ_ƒCƒ„ƒ‚ƒ“ƒh”...N:12, H:25, I:41

        // 90%...N:11+ H:23+ I:37+
        if (ratio >= 0.9f)
            grade = Grade.A;
        else if (ratio >= 0.8f) // N:10+ H:20+ I:33+
            grade = Grade.B;
        else if (ratio >= 0.7f) // N:9+ H:18+ I:29+
            grade = Grade.C; 
        else if (ratio >= 0.6f) // N:8+ H:15+ I:25+
            grade = Grade.D;
        else if (ratio >= 0.5f) // N:6+ H:13+ I:21+
            grade = Grade.E;

        return grade;
    }
}