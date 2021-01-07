using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextureManagers : MonoBehaviour, IInitializable
{
    #region Field

    [SerializeField]
    protected List<TextureManagerData> managers;

    #endregion Field

    #region Property

    public bool IsInitialized { get; protected set; }

    protected List<TextureManagerData> _Managers;

    public IReadOnlyList<TextureManagerData> Managers
    {
        get; protected set;
    }

    #endregion Property

    #region Method

    public virtual void Awake()
    {
        Initialize();
    }

    public virtual bool Initialize()
    {
        if (this.IsInitialized)
        {
            return false;
        }

        this.IsInitialized = true;

        this._Managers = new List<TextureManagerData>();

        this.Managers = this._Managers.AsReadOnly();

        foreach (var manager in this.managers)
        {
            this._Managers.Add(manager);
            manager.manager.Initialize();
        }

        return true;
    }

    #endregion Method
}