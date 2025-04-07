using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    //���콺 ������
    [SerializeField]
    private float lookSensitivity;
    [SerializeField]
    private float currentCameraRotationX;
    private float cameraRotationLimit = 90f;
    [SerializeField]
    private Camera theCamera;

    public float jump = 8f;
    private bool Bjump = true;

    public Slider O2bar, HPbar;
    public float O2 = 200, HP = 100, currentO2, currentHP;
    public float O2Time, sTime = 0.1f;

    private Rigidbody rb;
    public int MoveSpeed = 1;

    public GameObject Shop;
    public bool Shoping = false;
    public TextMeshProUGUI Money;
    public int money = 0;

    public GameObject Knaife;
    public GameObject Light;
    private int mode = 1;

    private bool nohit = true; //���� ���� ���� ����

    public float rayDistance = 100f; // ����(�÷��̾� ���� ��Ÿ�)�� �ִ� �Ÿ�

    void Start()
    {
        MonyUP();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentO2 = O2;
        currentHP = HP;

        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision) //�浹 ����
    {
        if (collision.gameObject.tag == "Floor")
        { //tag�� Floor�� ������Ʈ�� �浹���� ��
            Bjump = true; //Bjump�� �ٽ� false��
        }
    }
    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Arrow":
                Hit(5);
                break;
            case "Rotation":
                Hit(5);
                break;
            case "Axe":
                Hit(10);
                break;
            case "Thorn":
                Hit(5);
                break;
            case "Mob":
                Hit(10);
                break;
            case "Shop":
                Shop.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Shoping = true;
                break;
        }
    }

    void Hit(float Damage)
    {
        if(nohit == true)
        {
            currentHP -= Damage;
            Invoke("noHit", 0.5f);
            nohit = false;
        }
    }
    void noHit()
    {
        nohit = true;
    }
    // Update is called once per frame
    void Update()
    {
        O2decrease();
        O2bar.maxValue = O2;
        HPbar.maxValue = HP;

        O2bar.value = currentO2;
        HPbar.value = currentHP;

        if (Shoping == false)
        {
            CameraRotation();
            float moveZ = Input.GetAxisRaw("Horizontal"); // ���� �̵� (����, ������)
            float moveX = Input.GetAxisRaw("Vertical");   // ���� �̵� (��, ��)

            // �̵� ���� ����
            Vector3 moveDirection = new Vector3(moveZ, 0, moveX).normalized;
            // �̵� ó��
            transform.Translate(moveDirection * MoveSpeed * Time.deltaTime);

            if (Bjump == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    money += 1000;
                    MonyUP();
                    rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
                    Bjump = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (mode == 1)
                {
                    Light.SetActive(true);
                    Knaife.SetActive(false);
                    mode = 2;
                }
                else if (mode == 2)
                {
                    Light.SetActive(false);
                    Knaife.SetActive(true);
                    mode = 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack attack = Knaife.GetComponent<Attack>();
                attack.A();
                AttackRay();
            }


            if (Input.GetKeyDown(KeyCode.F1))
            {
                currentO2 = O2;
                currentHP = HP;
            }
        }
    }

    public void AttackRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // ���� �߻�
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // �浹�� ������Ʈ�� �±װ� "Mob"���� Ȯ��
            if (hit.collider.CompareTag("Mob"))
            {
                // MobAI ��ũ��Ʈ�� �����Ͽ� HP ���� ����
                Mob mobAI = hit.collider.GetComponent<Mob>();
                if (mobAI != null)
                {
                    mobAI.HP -= 1;
                    Debug.Log("Mob�� HP�� ���ҵǾ����ϴ�. ���� HP: " + mobAI.HP);
                }
                else
                {
                    Debug.LogWarning("�浹�� ������Ʈ�� MobAI ��ũ��Ʈ�� �����ϴ�.");
                }
            }
        }
    }
    public void O2HPup()
    {
        O2bar.maxValue = O2;
        HPbar.maxValue = HP;
        currentO2 = O2;
        currentHP = HP;
        O2bar.value = currentO2;
        HPbar.value = currentHP;
    }

    public void MonyUP()
    {
        Money.SetText(money.ToString());
    }
    public void SpeedUp1()
    {
        MoveSpeed += 5;
        Invoke("SpeedDown1", 10);
    }
    public void SpeedUp2()
    {
        MoveSpeed += 10;
        Invoke("SpeedDown2", 10);
    }
    public void SpeedDown1()
    {
        MoveSpeed -= 5;
        print("���� ����");
    }
    public void SpeedDown2()
    {
        MoveSpeed -= 10;
        print("���� ����");
    }
    private void O2decrease()
    {
        O2Time += 1 * Time.deltaTime;
        if (O2Time >= sTime)
        {
            currentO2 -= 0.1f;
            O2Time = 0;
        }
    }
    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _yRotation = Input.GetAxisRaw("Mouse X");
        float _cameraRotationX = _xRotation * lookSensitivity;

        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);

        transform.Rotate(Vector3.up * _yRotation * lookSensitivity);
    }
}
