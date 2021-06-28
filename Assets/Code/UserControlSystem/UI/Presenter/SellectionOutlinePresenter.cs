using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellectionOutlinePresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedValue;

    private ISelectable _lastSelectable;
    private bool _isMaterialAdded = false;

    private void Start()
    {
        _selectedValue.OnSelected += SetMaterial;
        SetMaterial(_selectedValue.CurrentValue);
    }

    private void SetMaterial(ISelectable selectable)
    {
        if (_lastSelectable != null && _isMaterialAdded)
        {
            for (int i = 0; i < _lastSelectable.MeshRenderers.Length; i++)
            {
                List<Material> newMaterials = new List<Material>(_lastSelectable.MeshRenderers[i].materials);
                newMaterials.RemoveAt(newMaterials.Count - 1);
                _lastSelectable.MeshRenderers[i].materials = newMaterials.ToArray();
            }
            _isMaterialAdded = false;
        }

        if (selectable != null)
        {
            _lastSelectable = selectable;
            for (int i = 0; i < selectable.MeshRenderers.Length; i++)
            {
                List<Material> newMaterials = new List<Material>(selectable.MeshRenderers[i].materials);
                newMaterials.Add(selectable.MaterialSellection);
                selectable.MeshRenderers[i].materials = newMaterials.ToArray();
            }
            _isMaterialAdded = true; 
        }
    }

    private void OnDestroy()
    {
        _selectedValue.OnSelected -= SetMaterial;
    }
}
