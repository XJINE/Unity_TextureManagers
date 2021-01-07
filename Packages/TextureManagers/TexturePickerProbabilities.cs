using UnityEngine;

public static class TexturePickerProbabilities
{
    public static TextureData Pick(TextureManagers managers)
    {
        // NOTE:
        // This is valid when the TextureManagerData.meta.x & TextureData.meta.x show probability.

        float seed = Random.value;

        TextureManager manager = null;

        foreach (var data in managers.Managers)
        {
            seed -= data.meta.x;

            if (seed <= 0)
            {
                manager = data.manager;
                break;
            }
        }

        manager = manager ?? managers.Managers[Random.Range(0, managers.Managers.Count)].manager;

        return TexturePickerProbability.Pick(manager);
    }
}