using UnityEngine;
using UnityEngine.UI;

public class GetPoseInfo : MonoBehaviour
{
    public enum GlassesARInfoRequest { Gaze, Pose, InterceptNormal, InterceptPosition, InterceptColliderName }
    public GlassesARInfoRequest glassesARInfoRequest;
    Text glassesARInformation;

    void Start()
    {
        Update();
    }

    void Update()
    {
        glassesARInformation = this.GetComponent<Text>();
        switch (glassesARInfoRequest)
        {
            case GlassesARInfoRequest.Gaze:
                glassesARInformation.text = "Gaze: " + Camera.main.transform.forward.ToString();
                break;
            case GlassesARInfoRequest.Pose:
                glassesARInformation.text = "Pose: " + Camera.main.transform.position.ToString();
                break;
            case GlassesARInfoRequest.InterceptNormal:
            case GlassesARInfoRequest.InterceptPosition:
            case GlassesARInfoRequest.InterceptColliderName:
                glassesARInformation.text = "Gaze Intercept " + InterceptInfo(Camera.main.transform.position, Camera.main.transform.forward, glassesARInfoRequest);
                break;
            default:
                glassesARInformation.text = " - Invalid glassesARInfoRequest";
                break;
        }
    }

    string InterceptInfo(Vector3 headPosition, Vector3 gazeDirection, GlassesARInfoRequest glassesARInfoRequest)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            switch (glassesARInfoRequest)
            {
                case GlassesARInfoRequest.InterceptPosition:
                    return "Location: " + hitInfo.point.ToString();
                case GlassesARInfoRequest.InterceptNormal:
                    return "Location Normal: " + Quaternion.FromToRotation(Vector3.up, hitInfo.normal).eulerAngles.ToString();
                case GlassesARInfoRequest.InterceptColliderName:
                    if (hitInfo.collider != null)
                    {
                        return "Collider Name: " + hitInfo.collider.name.ToString();
                    }
                    else
                    {
                        return "Collider Name is null";
                    }
                default:
                    return "- Invalid Intercept Info requested";
            }
        }
        else
        {
            return "- No intercepting object found";
        }
    }

}