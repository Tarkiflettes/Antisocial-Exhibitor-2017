using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public Transform DefensePrefab;
    public Transform GeneratorPrefab;
    public Button DefenseButton;
    public Button GeneratorButton;
    public Button CancelButton;
    public Button UpgradeButton;
    public Button CancelUpgradeButton;
    public Transform UpgradePanel;
    public GameObject LavalVirtual;
    public Material HighLightColor;
    public Material CaseColor;
    public LayerMask LayerMask;

    private bool _transactionInProgress = false;
    private Transform _transactionPrefab = null;
    private bool _upgradeInProgress = false;
    private Defense _upgradeDefense = null;

    // Use this for initialization
    void Start()
    {
        DefenseButton.onClick.AddListener(() => Buy(DefensePrefab));
        GeneratorButton.onClick.AddListener(() => Buy(GeneratorPrefab));
        CancelButton.onClick.AddListener(() => CancelBuy());
        UpgradeButton.onClick.AddListener(() => Upgrade());
        CancelUpgradeButton.onClick.AddListener(() => CancelUpgrade());
        CancelButton.gameObject.SetActive(false);
        UpgradePanel.gameObject.SetActive(false);
    }

    private void CancelUpgrade()
    {
        if (_upgradeDefense != null)
            _upgradeDefense.transform.parent.GetComponentInParent<Renderer>().material = CaseColor;
        _upgradeDefense = null;
        _upgradeInProgress = false;
        UpgradePanel.gameObject.SetActive(false);
    }

    private void CancelBuy()
    {
        SetTransaction(false);
    }

    private void Upgrade()
    {
        CancelBuy();
        if (_upgradeDefense == null)
            return;
        if (GetComponent<Player>().Coin >= _upgradeDefense.LevelUpCost)
        {
            GetComponent<Player>().Coin -= _upgradeDefense.LevelUpCost;
            _upgradeDefense.LevelUpDefense();

            SetUpgradePanel();
        }
    }

    private void SetUpgradePanel()
    {
        UpgradePanel.gameObject.SetActive(true);
        foreach (Transform t in UpgradeButton.GetComponentsInChildren<Transform>())
        {
            if (t.name == "Level")
            {
                t.GetComponent<Text>().text = _upgradeDefense.Level.ToString();
            }
            else if (t.name == "Image")
            {
                t.GetComponent<Image>().sprite = _upgradeDefense.Sprite;
            }
            else if (t.name == "Cost")
            {
                t.GetComponent<Text>().text = _upgradeDefense.LevelUpCost.ToString() + " $";
            }
        }
    }

    private void Buy(Transform prefab)
    {
        CancelUpgrade();
        if (GetComponent<Player>().Coin >= prefab.GetComponent<Defense>().Cost)
        {
            _transactionPrefab = prefab;
            SetTransaction(true);
        }
        else
        {
            CancelBuy();
        }
    }

    private void SetTransaction(bool state)
    {
        if (!state)
            _transactionPrefab = null;
        CancelButton.gameObject.SetActive(state);
        GeneratorButton.gameObject.SetActive(!state);
        DefenseButton.gameObject.SetActive(!state);
        _transactionInProgress = state;
        HighLightSpaces();
    }

    private void HighLightSpaces()
    {
        Transform[] spaces = LavalVirtual.GetComponentsInChildren<Transform>();
        foreach (Transform cs in spaces)
        {
            if (cs.tag == "Case" && cs.GetComponentsInChildren<Transform>().Length == 1)
            {
                cs.GetComponent<Renderer>().material = (_transactionInProgress) ? HighLightColor : CaseColor;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CancelBuy();
            Buy(DefensePrefab);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CancelBuy();
            Buy(GeneratorPrefab);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CancelBuy();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Upgrade();
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity, LayerMask))
            {
                if (hitInfo.transform.tag == "Case")
                {
                    if (hitInfo.transform.GetComponentsInChildren<Transform>().Length == 1 && _transactionInProgress)
                    {
                        GetComponent<Player>().Coin -= _transactionPrefab.GetComponent<Defense>().Cost;
                        Transform temp = Instantiate(_transactionPrefab, hitInfo.transform.position, _transactionPrefab.transform.rotation);
                        temp.SetParent(hitInfo.transform);
                        hitInfo.transform.GetComponent<Renderer>().material = CaseColor;
                        CancelBuy();
                    }
                    else if (hitInfo.transform.GetComponentsInChildren<Transform>().Length > 1)
                    {
                        CancelUpgrade();
                        _upgradeInProgress = true;
                        _upgradeDefense = hitInfo.transform.GetComponentInChildren<Defense>();
                        _upgradeDefense.transform.parent.GetComponentInParent<Renderer>().material = HighLightColor;
                        SetUpgradePanel();
                    }

                }
            }
        }

    }
}
