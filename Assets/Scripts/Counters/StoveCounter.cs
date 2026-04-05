using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;

    private float fryingTimer;
    private FryingRecipeSO fryingRecipeSO;
    private void Update()
    {
        if (HasKitchenObject())
        {
            fryingTimer += Time.deltaTime;
            
            if (fryingTimer > fryingRecipeSO.fryingTimerMax)
            {
                fryingTimer = 0f;
                Debug.Log("fried");
                GetKitchenObject().DestroySelf();

                KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);
            }

            Debug.Log(fryingTimer);
        }
    }

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                }
            }
            else
            {
                
            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                
            }else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            } 
        }
    }
    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        return fryingRecipeSO != null;
    }

    
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == inputKitchenObjectSO)	
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }
}
