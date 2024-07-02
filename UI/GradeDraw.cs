using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradeDraw : MonoBehaviour
{
    public enum Grade
    {
        A, B, C, D, E, F
    }

    [SerializeField]
    List<Sprite> GradeSprites = new List<Sprite>();

    Image img;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        img = GetComponent<Image>();
    }

    protected void SetGradeTexture(Grade grade)
    {
        img.sprite = GradeSprites[(int)grade];
    }
}
