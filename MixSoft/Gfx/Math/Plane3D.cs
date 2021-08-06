using Microsoft.DirectX;

namespace MixSoft.Gfx.Math
{
    public readonly struct Plane3D
    {
        // Plane's normal.
        public readonly Vector3 Normal;
         
        // Distance from origin (0,0,0) to plane along its normal.
        public readonly float Distance;

        public Plane3D(Vector3 normal, float distance)
        {
            Normal = normal.Normalized();
            Distance = distance;
        }

        public Plane3D(Vector3 normal, Vector3 point) :
            this(normal, -normal.Dot(point)) { }

        // Project point on a plane. 
        // planeOrigin - origin of a plane
        // vector - Vector from plane origin to projected point
        public (Vector3 planeOrigin, Vector3 vector) ProjectVector(Vector3 vector)
        {
            var planeOrigin = ProjectPoint(new Vector3());
            return (planeOrigin, ProjectPoint(vector) - planeOrigin);
        }

         
        // Project point on a plane.
        // <remarks>
        // "https://en.wikipedia.org/wiki/3D_projection"
        // "https://en.wikipedia.org/wiki/Projection_(linear_algebra)"
        // </remarks>
        public Vector3 ProjectPoint(Vector3 point)
        {
            return point - (Normal.Dot(point) + Distance) * Normal;
        }
    }
}
