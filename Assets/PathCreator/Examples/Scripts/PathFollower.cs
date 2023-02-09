using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public PathCreator attackPath;

        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 4;
        float distanceTravelled;

        Vector3 enemyPosition;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
            //enemyPosition = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        }

        void Update()
        {
            Vector3 dir = new Vector3(enemyPosition.x - transform.position.x, enemyPosition.y - transform.position.y, 0.0f);

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                enemyPosition = transform.position;
                transform.rotation = Quaternion.Euler(0, angle, 0);
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}