using System;
using UnityEngine;
using UnityEngine.Purchasing;


public class IAPManager2 : MonoBehaviour , IStoreListener
{
    private static IStoreController m_StoreController;          // The Unity Purchasing system.
    private static IExtensionProvider m_StoreExtensionProvider;

    private int gemsPresent;
    private int gemsNew;

    //public GameObject AdsManager;

    //public Text gemsText;
    //public Text gemsText2;

    //public static IAPManager instance;


    //Step 1 create your products
    private string remove_ads = "jetrun_remove_ads_purchase";
    private string buy50Gems = "jetrun_buy_50_gems";
    private string buy100Gems = "jetrun_buy_100_gems";
    private string buy200Gems = "jetrun_buy_200_gems";
    private string buy500Gems = "jetrun_buy_500_gems";

    void Start()
    {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }

    }





    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Step 2 choose if your product is a consumable or non consumable
        builder.AddProduct(remove_ads, ProductType.NonConsumable);
        builder.AddProduct(buy50Gems, ProductType.Consumable);
        builder.AddProduct(buy100Gems, ProductType.Consumable);
        builder.AddProduct(buy200Gems, ProductType.Consumable);
        builder.AddProduct(buy500Gems, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    //Step 3 Create methods
    public void Remove_ads()
    {
        BuyProductID(remove_ads);
    }
    public void Buy50Gems()
    {
        BuyProductID(buy50Gems);
    }
    public void Buy100Gems()
    {
        BuyProductID(buy100Gems);
    }
    public void Buy200Gems()
    {
        BuyProductID(buy200Gems);
    }
    public void Buy500Gems()
    {
        BuyProductID(buy500Gems);
    }

    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, remove_ads, StringComparison.Ordinal))
        {
            //Debug.Log("ads removed");
            PlayerPrefs.SetInt("AdsRemovedSave", 1);
            //AdsManager.GetComponent<AdsManager>().RemovingAdsNow();

        }
        else if (String.Equals(args.purchasedProduct.definition.id, buy50Gems, StringComparison.Ordinal))
        {
            //Debug.Log("50 gems");
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent + 50;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            //gemsText.text = gemsNew.ToString() + " Gems";
            //gemsText2.text = gemsNew.ToString() + " Gems";
        }
        else if (String.Equals(args.purchasedProduct.definition.id, buy100Gems, StringComparison.Ordinal))
        {
            //Debug.Log("100 gems");
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent + 100;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            //gemsText.text = gemsNew.ToString() + " Gems";
            //gemsText2.text = gemsNew.ToString() + " Gems";
        }
        else if (String.Equals(args.purchasedProduct.definition.id, buy200Gems, StringComparison.Ordinal))
        {
            //Debug.Log("200 gems");
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent + 200;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            //gemsText.text = gemsNew.ToString() + " Gems";
            //gemsText2.text = gemsNew.ToString() + " Gems";
        }
        else if (String.Equals(args.purchasedProduct.definition.id, buy500Gems, StringComparison.Ordinal))
        {
            //Debug.Log("500 gems");
            gemsPresent = PlayerPrefs.GetInt("GemsNum", 0);
            gemsNew = gemsPresent + 500;
            PlayerPrefs.SetInt("GemsNum", gemsNew);
            //gemsText.text = gemsNew.ToString() + " Gems";
            //gemsText2.text = gemsNew.ToString() + " Gems";
        }

        else
        {
            //Debug.Log("Purchase Failed");
        }
        return PurchaseProcessingResult.Complete;
    }










    //**************************** Dont worry about these methods ***********************************
    /*private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
    }*/

    /*private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }*/

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
