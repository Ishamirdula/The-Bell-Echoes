using UnityEngine;

public class GhostAdvancedAI : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Movement")]
    public float speed = 2f;

    [Header("Damage")]
    public float damage = 10f;

    [Header("Vision Settings")]
    public float viewDistance = 20f;

    [Header("Jumpscare Settings")]
    public float scareDistance = 2f;
    public Transform jumpscarePoint;
    public Light jumpscareLight;
    public Transform resetPoint;
    public float shakeAmount = 0.2f;
    public float jumpscareDuration = 6f;

    private Camera playerCamera;

    private bool isJumpscaring = false;
    private float jumpscareTimer = 0f;
    private float blinkTimer = 0f;

    private float fixedY;

    void Start()
    {
        playerCamera = Camera.main;
        fixedY = transform.position.y;

        if (jumpscareLight != null)
            jumpscareLight.intensity = 0f; // start OFF
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (!isJumpscaring)
        {
            if (!CanPlayerSeeGhost())
            {
                MoveTowardsPlayer();
            }

            if (distance < scareDistance)
            {
                TriggerJumpscare();
            }
        }
        else
        {
            DoJumpscareEffect();
        }

        // 🔒 Always stay on same floor
        transform.position = new Vector3(
            transform.position.x,
            fixedY,
            transform.position.z
        );
    }

    // 👻 SMART MOVEMENT
    void MoveTowardsPlayer()
    {
        Vector3 forward = (player.position - transform.position).normalized;

        Vector3[] directions = new Vector3[4];
        directions[0] = forward;
        directions[1] = Quaternion.Euler(0, -45, 0) * forward;
        directions[2] = Quaternion.Euler(0, 45, 0) * forward;
        directions[3] = -forward;

        Vector3 chosenDir = Vector3.zero;

        for (int i = 0; i < directions.Length; i++)
        {
            RaycastHit hit;

            if (!Physics.Raycast(transform.position, directions[i], out hit, 1.5f))
            {
                chosenDir = directions[i];
                break;
            }
            else if (hit.collider.CompareTag("Player"))
            {
                chosenDir = directions[i];
                break;
            }
        }

        if (chosenDir != Vector3.zero)
        {
            Vector3 move = chosenDir * speed * Time.deltaTime;

            transform.position += new Vector3(move.x, 0, move.z);

            Vector3 lookDir = chosenDir;
            lookDir.y = 0;

            if (lookDir != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(lookDir);
            }
        }
    }

    // 👁️ VISION CHECK
    bool CanPlayerSeeGhost()
    {
        Vector3 dir = (transform.position - playerCamera.transform.position).normalized;

        float dot = Vector3.Dot(playerCamera.transform.forward, dir);

        if (dot > 0.8f)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, dir, out hit, viewDistance))
            {
                if (hit.transform == transform)
                {
                    return true;
                }
            }
        }

        return false;
    }

    // 😈 START JUMPSCARE
    void TriggerJumpscare()
    {
        isJumpscaring = true;
        jumpscareTimer = 0f;

        Vector3 pos = jumpscarePoint.position;
        transform.position = new Vector3(pos.x, fixedY, pos.z);

        // Face camera
        Vector3 lookDir = playerCamera.transform.position - transform.position;
        lookDir.y = 0;

        if (lookDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDir);
        }

        speed = 0f;

        var controller = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        if (controller != null)
            controller.enabled = false;

        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
            audio.Play();
    }

    // 🔴 LIGHT FLICKER + 👻 SHAKE
    void DoJumpscareEffect()
    {
        jumpscareTimer += Time.deltaTime;

        // 🔴 FAST RED LIGHT FLICKER
        blinkTimer += Time.deltaTime * 40f;

        if (jumpscareLight != null)
        {
            float flicker = Mathf.Abs(Mathf.Sin(blinkTimer));

            if (flicker > 0.5f)
                jumpscareLight.intensity = 8f; // ON
            else
                jumpscareLight.intensity = 0f; // OFF
        }

        // 👻 SHAKE (no vertical movement)
        Vector3 offset = new Vector3(
            Random.Range(-shakeAmount, shakeAmount),
            0f,
            Random.Range(-shakeAmount, shakeAmount)
        );

        transform.position = jumpscarePoint.position + offset;

        if (jumpscareTimer >= jumpscareDuration)
        {
            EndJumpscare();
        }
    }

    // 🔁 RESET
    void EndJumpscare()
    {
        isJumpscaring = false;

        if (jumpscareLight != null)
            jumpscareLight.intensity = 0f;

        var controller = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        if (controller != null)
            controller.enabled = true;

        // Move to your fixed reset point
        transform.position = new Vector3(
            resetPoint.position.x,
            fixedY,
            resetPoint.position.z
        );

        // Face player
        Vector3 lookDir = player.position - transform.position;
        lookDir.y = 0;

        if (lookDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDir);
        }

        speed = 2f;
    }

    // 💀 DAMAGE
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance < 2f)
            {
                PlayerHealth health = other.GetComponent<PlayerHealth>();

                if (health != null)
                    health.TakeDamage(damage);
            }
        }
    }
}



// using UnityEngine;

// public class GhostAdvancedAI : MonoBehaviour
// {
//     [Header("Player")]
//     public Transform player;

//     [Header("Movement")]
//     public float speed = 2f;

//     [Header("Damage")]
//     public float damage = 10f;

//     [Header("Vision Settings")]
//     public float viewDistance = 20f;

//     [Header("Jumpscare Settings")]
//     public float scareDistance = 2f;
//     public Transform jumpscarePoint;
//     public Light jumpscareLight;
//     public Transform resetPoint;
//     public float shakeAmount = 0.2f;
//     public float jumpscareDuration = 6f;

//     private Camera playerCamera;

//     private bool isJumpscaring = false;
//     private float jumpscareTimer = 0f;
//     private float blinkTimer = 0f;

//     private float fixedY; // locks ghost to same floor

//     void Start()
//     {
//         playerCamera = Camera.main;
//         fixedY = transform.position.y;
//     }

//     void Update()
//     {
//         float distance = Vector3.Distance(transform.position, player.position);

//         if (!isJumpscaring)
//         {
//             if (!CanPlayerSeeGhost())
//             {
//                 MoveTowardsPlayer();
//             }

//             if (distance < scareDistance)
//             {
//                 TriggerJumpscare();
//             }
//         }
//         else
//         {
//             DoJumpscareEffect();
//         }
//     }

//     // 👻 SMART MOVEMENT (NO NAVMESH)
//     void MoveTowardsPlayer()
//     {
//         Vector3[] directions = new Vector3[4];

//         // Priority directions
//         directions[0] = (player.position - transform.position).normalized; // forward
//         directions[1] = Quaternion.Euler(0, -45, 0) * directions[0]; // left
//         directions[2] = Quaternion.Euler(0, 45, 0) * directions[0];  // right
//         directions[3] = -directions[0]; // back

//         Vector3 chosenDir = Vector3.zero;

//         for (int i = 0; i < directions.Length; i++)
//         {
//             RaycastHit hit;

//             // Check if path is clear
//             if (!Physics.Raycast(transform.position, directions[i], out hit, 1.5f))
//             {
//                 chosenDir = directions[i];
//                 break;
//             }
//             else if (hit.collider.CompareTag("Player"))
//             {
//                 chosenDir = directions[i];
//                 break;
//             }
//         }

//         // Move in chosen direction
//         if (chosenDir != Vector3.zero)
//         {
//             Vector3 move = chosenDir * speed * Time.deltaTime;

//             transform.position += new Vector3(move.x, 0, move.z);

//             // Rotate only Y axis
//             Vector3 lookDir = chosenDir;
//             lookDir.y = 0;

//             if (lookDir != Vector3.zero)
//             {
//                 transform.rotation = Quaternion.LookRotation(lookDir);
//             }
//         }

//         // 🔒 Lock height
//         transform.position = new Vector3(
//             transform.position.x,
//             fixedY,
//             transform.position.z
//         );
//     }



//     // 👁️ REAL VISION CHECK
//     bool CanPlayerSeeGhost()
//     {
//         Vector3 dir = (transform.position - playerCamera.transform.position).normalized;

//         float dot = Vector3.Dot(playerCamera.transform.forward, dir);

//         if (dot > 0.8f)
//         {
//             RaycastHit hit;
//             if (Physics.Raycast(playerCamera.transform.position, dir, out hit, viewDistance))
//             {
//                 if (hit.transform == transform)
//                 {
//                     return true;
//                 }
//             }
//         }

//         return false;
//     }

//     // 😈 START JUMPSCARE
//     void TriggerJumpscare()
//     {
//         isJumpscaring = true;
//         jumpscareTimer = 0f;

//         // Move ghost to camera front
//         transform.position = jumpscarePoint.position;
//         // transform.rotation = jumpscarePoint.rotation;
//         // Make ghost face the camera
//         Vector3 lookDir = playerCamera.transform.position - transform.position;
//         lookDir.y = 0;

//         if (lookDir != Vector3.zero)
//         {
//             transform.rotation = Quaternion.LookRotation(lookDir);
//         }

//         fixedY = jumpscarePoint.position.y;

//         speed = 0f;

//         // Disable player movement
//         var controller = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
//         if (controller != null)
//             controller.enabled = false;

//         // Play sound (if exists)
//         AudioSource audio = GetComponent<AudioSource>();
//         if (audio != null)
//             audio.Play();
//     }

//     // 🔴 BLINK + 👻 SHAKE
//     void DoJumpscareEffect()
//     {
//         jumpscareTimer += Time.deltaTime;

//         // 🔴 blinking effect
//         blinkTimer += Time.deltaTime * 10f;
//         float blink = Mathf.Abs(Mathf.Sin(blinkTimer));
//         playerCamera.backgroundColor = Color.Lerp(Color.black, Color.red, blink);

//         // 👻 controlled shake (no flying)
//         Vector3 offset = new Vector3(
//             Random.Range(-shakeAmount, shakeAmount),
//             Random.Range(-shakeAmount * 0.2f, shakeAmount * 0.2f),
//             Random.Range(-shakeAmount, shakeAmount)
//         );

//         transform.position = jumpscarePoint.position + offset;

//         // ⏱️ END jumpscare
//         if (jumpscareTimer >= jumpscareDuration)
//         {
//             EndJumpscare();
//         }
//     }

//     // 🔁 RESET
//         void EndJumpscare()
//     {
//         isJumpscaring = false;

//         // Reset screen
//         playerCamera.backgroundColor = Color.black;

//         // Enable player movement
//         var controller = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
//         if (controller != null)
//             controller.enabled = true;

//         // 👻 Move ghost to your custom reset point
//         transform.position = new Vector3(
//             resetPoint.position.x,
//             fixedY,
//             resetPoint.position.z
//         );

//         // Face player again
//         Vector3 lookDir = player.position - transform.position;
//         lookDir.y = 0;

//         if (lookDir != Vector3.zero)
//         {
//             transform.rotation = Quaternion.LookRotation(lookDir);
//         }
//     }

//     // 💀 DAMAGE (ONLY WHEN CLOSE)
//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.GetComponent<CharacterController>() != null)
//         {
//             float distance = Vector3.Distance(transform.position, player.position);

//             if (distance < 2f)
//             {
//                 PlayerHealth health = other.GetComponent<PlayerHealth>();

//                 if (health != null)
//                     health.TakeDamage(damage);
//             }
//         }
//     }
// }

