using System.IO;
using UnityEngine;
using Unity.VectorGraphics;
using static Unity.VectorGraphics.SVGParser;
using UnityEditor;

public class DiceGenerator : MonoBehaviour
{
    public float pixelsPerUnit = 0.6f;
    public ushort gradientResolution = 64;

    [Space]
    public string batchName = "";
    public int startValue = 1;
    public int endValue = 6;
    public Color circlesColor;

    [Space]
    public Color faceColor;
    public Color shadowColor;
    public Color borderColor;

    private SceneInfo sceneInfo;

    void Start()
    {
        string svg =
            @"<svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""68"" height=""68"" viewBox=""0 0 68 68"">
  <defs>
    <clipPath id=""clip-Die"">
      <rect width=""68"" height=""68""/>
    </clipPath>
  </defs>
  <g id=""Die"" clip-path=""url(#clip-Die)"">
    <rect width=""68"" height=""68"" fill=""#fff"" fill-opacity=""0""/>
    <g id=""single_die_simple"" data-name=""single die simple"" transform=""translate(-0.05 -70)"">
      <path id=""border"" d=""M23.067,70H56.191Q68.05,70,68.05,81.85v44.3Q68.05,138,56.191,138H11.909Q.05,138,.05,125.2V81.85Q.05,70,11.909,70H23.067"" fill=""#305ae1""/>
      <path id=""shadow"" d=""M21.614,72H11.907Q2.05,72,2.05,81.85v44.3q0,9.85,9.857,9.85H56.19q9.857,0,9.857-9.85V81.85q0-9.85-9.857-9.85H21.614"" transform=""translate(0.001)"" fill=""#eee""/>
      <path id=""face"" d=""M22.114,73.25Q3.95,73.85,3.35,92v23.95Q4,134.7,23.415,134.7H44.63q20.165,0,20.165-20.15V93.4q0-19.5-18.864-20.15H22.114"" transform=""translate(0.002)"" fill=""#fff""/>
      <path id=""circle-7"" d=""M40,104a6.01,6.01,0,0,0-10.25-4.25A5.786,5.786,0,0,0,28,104l.05.5.05.4a5.986,5.986,0,0,0,10.15,3.35,6.263,6.263,0,0,0,1.7-3.2l.05-.55V104"" transform=""translate(18.05 18)"" fill=""#656fb2""/>
      <path id=""circle-6"" d=""M40,104a6.01,6.01,0,0,0-10.25-4.25A5.786,5.786,0,0,0,28,104l.05.5.05.4a5.986,5.986,0,0,0,10.15,3.35,6.263,6.263,0,0,0,1.7-3.2l.05-.55V104"" transform=""translate(18.05)"" fill=""#656fb2""/>
      <path id=""circle-5"" d=""M40,104a6.01,6.01,0,0,0-10.25-4.25A5.786,5.786,0,0,0,28,104l.05.5.05.4a5.986,5.986,0,0,0,10.15,3.35,6.263,6.263,0,0,0,1.7-3.2l.05-.55V104"" transform=""translate(18.05 -18)"" fill=""#656fb2""/>
      <path id=""circle-4"" d=""M40,104a6.01,6.01,0,0,0-10.25-4.25A5.786,5.786,0,0,0,28,104l.05.5.05.4a5.986,5.986,0,0,0,10.15,3.35,6.263,6.263,0,0,0,1.7-3.2l.05-.55V104"" transform=""translate(0.05)"" fill=""#656fb2""/>
      <path id=""circle-3"" d=""M40,104a6.01,6.01,0,0,0-10.25-4.25A5.786,5.786,0,0,0,28,104l.05.5.05.4a5.986,5.986,0,0,0,10.15,3.35,6.263,6.263,0,0,0,1.7-3.2l.05-.55V104"" transform=""translate(-17.95 18)"" fill=""#656fb2""/>
      <path id=""circle-2"" d=""M40,104a6.01,6.01,0,0,0-10.25-4.25A5.786,5.786,0,0,0,28,104l.05.5.05.4a5.986,5.986,0,0,0,10.15,3.35,6.263,6.263,0,0,0,1.7-3.2l.05-.55V104"" transform=""translate(-17.95)"" fill=""#656fb2""/>
      <path id=""circle-1"" d=""M40,104a6.01,6.01,0,0,0-10.25-4.25A5.786,5.786,0,0,0,28,104l.05.5.05.4a5.986,5.986,0,0,0,10.15,3.35,6.263,6.263,0,0,0,1.7-3.2l.05-.55V104"" transform=""translate(-17.95 -18)"" fill=""#656fb2""/>
    </g>
  </g>
</svg>";

        // Dynamically import the SVG data, and tessellate the resulting vector scene.
        sceneInfo = SVGParser.ImportSVG(new StringReader(svg));

        GenerateAssets();
    }

    private void GenerateAssets()
    {
        for (int i = startValue; i <= endValue; i++)
        {
            GenerateSprite(i);
        }
    }

    void OnDisable()
    {
        GameObject.Destroy(GetComponent<SpriteRenderer>().sprite);
    }

    private void GenerateSprite(int dieValue)
    {
        var tessOptions = new VectorUtils.TessellationOptions()
        {
            StepDistance = 100.0f,
            MaxCordDeviation = 0.5f,
            MaxTanAngleDeviation = 0.1f,
            SamplingStepSize = 0.01f
        };

        ColorShape("face", faceColor);
        ColorShape("shadow", shadowColor);
        ColorShape("border", borderColor);

        ColorCircles(dieValue, circlesColor);

        var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);

        // Build a sprite with the tessellated geometry.
        var sprite = VectorUtils.BuildSprite(geoms, pixelsPerUnit, VectorUtils.Alignment.Center, Vector2.zero, gradientResolution, true);
        GetComponent<SpriteRenderer>().sprite = sprite;
        SaveSprite(sprite, dieValue);
    }

    private void SaveSprite(Sprite sprite, int dieValue)
    {
        AssetDatabase.CreateAsset(sprite, "Assets/Images/" + batchName + "-" + dieValue + ".asset");
    }

    private void ColorShape(string shapeID, Color color)
    {
        var shape = sceneInfo.NodeIDs[shapeID].Shapes[0];
        shape.Fill = new SolidFill() { Color = new Color(color.r, color.g, color.b, color.a) };
    }

    /*private void ColorShape(string shapeID, Color color, bool dashed)
    {
        var shape = sceneInfo.NodeIDs[shapeID].Shapes[0];
        shape.Fill = new SolidFill() { Color = new Color(color.r, color.g, color.b, 0) };
        shape.PathProps = new PathProperties()
        {
            Stroke = new Stroke() { Color = Color.black, HalfThickness = 2f, Pattern = new float[] { 8f, 4f } }
        };
    }*/

    private void ColorCircles(int diceValue, Color fillColor)
    {
        if(diceValue>=0 && diceValue<7)
        {
            string diceString = GetDiceString(diceValue);
            for (int i = 0; i < 7; i++)
            {
                Shape shape = sceneInfo.NodeIDs["circle-" + (i + 1)].Shapes[0];

                if (diceString[i] == '0')
                {
                    shape.Fill = new SolidFill() { Color = new Color(fillColor.r, fillColor.g, fillColor.b, 0) };
                }
                else
                {
                    shape.Fill = new SolidFill() { Color = new Color(fillColor.r, fillColor.g, fillColor.b, 1) };
                }
            }
        }
    }

    private string GetDiceString(int diceValue)
    {
        string diceString = "";
        switch (diceValue)
        {
            case 0:
                diceString = "0000000";
                break;
            case 1:
                diceString = "0001000";
                break;
            case 2:
                diceString = "1000001";
                break;
            case 3:
                diceString = "1001001";
                break;
            case 4:
                diceString = "1010101";
                break;
            case 5:
                diceString = "1011101";
                break;
            case 6:
                diceString = "1110111";
                break;
            default:
                break;
        }
        return diceString;
    }
}
