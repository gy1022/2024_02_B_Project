
public class RecipeList
{
    public static CraftingRecipe[] KitchenRecipes = new CraftingRecipe[]
   {
        new CraftingRecipe
        {
            itemName = "��ä ��Ʃ",
            resultItem = ItemType.VegetableStow,
            resultAmount = 1,
            hungerRestoreAmount = 40f,
            requiredItems = new ItemType[] {ItemType.Plant , ItemType.Bush },
            requiredAmounts = new int[] {2,1}
        },
        new CraftingRecipe
        {
            itemName = "���� ������",
            resultItem = ItemType.FruitSalad,
            resultAmount = 1,
            hungerRestoreAmount = 60f,
            requiredItems = new ItemType[] {ItemType.Plant , ItemType.Bush },
            requiredAmounts = new int[] {3,3}
        },
    };

    public static CraftingRecipe[] KitchenRecipes = new CraftingRecipe[]
    {
        new CraftingRecipe
        {
            itemName = "���� ŰƮ",
            resultItem = ItemType.RepairKit,
            resultAmount = 1,
            hungerRestoreAmount = 25f,
            requiredItems = new ItemType[] {ItemType.Plant , ItemType.Bush },
            requiredAmounts = new int[] {3}
        },

    };
}
