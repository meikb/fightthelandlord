﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.ServiceModel;

/// <summary>
/// 联络中心回调对象
/// </summary>
public partial class ContactCenterCallback : IContactCenterCallback
{
    private IContactCenterCallbackHandler _handler;
    private ContactCenterProxy _proxy;

    public ContactCenterCallback(IContactCenterCallbackHandler handler)
    {
        this._handler = handler;
        InstanceContext site = new InstanceContext(this);
        this._proxy = new ContactCenterProxy(site);
        handler.ContactCenterProxy = this._proxy;
        this._proxy.BeginJoin(handler.ServiceID, new AsyncCallback(OnEndJoin), null);
    }

    #region IContactCenterCallback Members

    public void Receive(int senderId, byte[][] data)
    {
        _handler.Receive(senderId, data);
    }

    public void ReceiveWhisper(int senderId, byte[][] data)
    {
        _handler.ReceiveWhisper(senderId, data);
    }

    public void ServiceEnter(int id)
    {
        _handler.ServiceEnter(id);
    }

    public void ServiceLeave(int id)
    {
        _handler.ServiceLeave(id);
    }

    public bool Ping(byte[][] data)
    {
        return _handler.Ping(data);
    }

    #endregion

    private void OnEndJoin(IAsyncResult iar)
    {
        try
        {
            int[] list = _proxy.EndJoin(iar);

            if (list == null)
            {
                _handler.JoinFailed();
                this.ExitServiceSession();
            }
            else
            {
                _handler.JoinSuccessed(list);
            }

        }
        catch (Exception e)
        {
            _handler.ConnectField(e);
            ExitServiceSession();
        }

    }

    private void ExitServiceSession()
    {
        try
        {
            _proxy.Leave();
        }
        catch { }
        finally
        {
            if (_proxy != null)
            {
                _proxy.Abort();
                _proxy.Close();
                _proxy = null;
            }
        }
    }

}
