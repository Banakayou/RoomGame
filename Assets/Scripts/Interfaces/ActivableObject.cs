﻿using System;
using UnityEngine;

public abstract class ActivableObject : InteractiveObject
{
    public AudioSource SondToPlayOnActivate = null;

    protected bool m_isActivated;
	
	bool m_canBeActivated = true;
    bool m_updateState = true;

    public bool isActivated
    {
        get { return m_isActivated; }
        set { m_isActivated = value; }
    }

    public bool canBeActivated
	{
		set { m_canBeActivated = value; }
	}

	/// <summary>
	/// Should m_isActivated be updated on activate()/deactivate() call ?
	/// </summary>
	public bool updateState
	{
		set { m_updateState = value; }
	}

	/// <summary>
	/// Activate the object, return true if successfully activated.
	/// </summary>
	public bool activate()
    {
        if (!m_isActivated && m_canBeActivated)
        {
            specificActivation();
            m_isActivated = true && m_updateState;

            if (SondToPlayOnActivate!=null)
            {
                SondToPlayOnActivate.Play();
            }

            return true;
        }

		return false;
	}

    /// <summary>
    /// Dectivate the object, return true if successfully deactivated.
    /// </summary>
    public bool deactivate()
    {
        if (m_isActivated)
        {
            specificDeactivation();
            m_isActivated = false || !m_updateState;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Called by activate().
    /// </summary>
    protected abstract void specificActivation();

    /// <summary>
    /// Called by deactivate().
    /// </summary>
    protected virtual void specificDeactivation()
    {
        throw new NotImplementedException();
    }
}