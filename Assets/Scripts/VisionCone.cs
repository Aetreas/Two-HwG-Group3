using System.Collections;

using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;



public class VisionCone : MonoBehaviour//this script is purely a visual indicator to the "danger zone" in which the player will be detected

{

    public Material VisionConeMaterial;

    public float VisionRange;

    public float VisionAngle;

    public LayerMask VisionObstructingLayer;//layer with objects that obstruct the enemy view

    public LayerMask PlayerLayer;//layer that detects the player character

    public int VisionConeResolution = 120;

    Mesh VisionConeMesh;

    MeshFilter MeshFilter_;


    void Start()

    {

        transform.AddComponent<MeshRenderer>().material = VisionConeMaterial;

        MeshFilter_ = transform.AddComponent<MeshFilter>();

        VisionConeMesh = new Mesh();

        VisionAngle *= Mathf.Deg2Rad;

    }



    

    void Update()

    {

        DrawVisionCone();//cone is updated every frame

    }



    void DrawVisionCone()//creates the vision cone

    {

	int[] triangles = new int[(VisionConeResolution - 1) * 3];

    	Vector3[] Vertices = new Vector3[VisionConeResolution + 1];

        Vertices[0] = Vector3.zero;

        float Currentangle = -VisionAngle / 2;

        float angleIcrement = VisionAngle / (VisionConeResolution - 1);

        float Sine;

        float Cosine;



        for (int i = 0; i < VisionConeResolution; i++)

        {

            Sine = Mathf.Sin(Currentangle);

            Cosine = Mathf.Cos(Currentangle);

            Vector3 RaycastDirection = (transform.forward * Cosine) + (transform.right * Sine);

            Vector3 VertForward = (Vector3.forward * Cosine) + (Vector3.right * Sine);

            if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit hit, VisionRange, VisionObstructingLayer))

            {

                Vertices[i + 1] = VertForward * hit.distance;

            }

            else

            {

                Vertices[i + 1] = VertForward * VisionRange;

            }





            Currentangle += angleIcrement;

        }

        for (int i = 0, j = 0; i < triangles.Length; i += 3, j++)

        {

            triangles[i] = 0;

            triangles[i + 1] = j + 1;

            triangles[i + 2] = j + 2;

        }

        VisionConeMesh.Clear();

        VisionConeMesh.vertices = Vertices;

        VisionConeMesh.triangles = triangles;

        MeshFilter_.mesh = VisionConeMesh;

    }





}