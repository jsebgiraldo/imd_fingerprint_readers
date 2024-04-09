// <copyright file="ReflectionHelper.cs" company="Smartmatic Corp.">
//   Smartmatic Corp. All Rights Reserved.
// </copyright>
// <author>Angel Castillo</author>
// <date>3/14/2016 5:18:28 PM</date>
//
// Confidential Information of Smartmatic Labs. Not for disclosure or distribution
// prior written consent. This software contains code, techniques and know-how which
// is confidential and proprietary to Smartmatic.
//
// Use of this software is subject to the terms of an end user license agreement.

using System;
using System.Reflection;
using System.Globalization;
using System.ComponentModel;
using System.Threading;
using System.Collections.Generic;

namespace Utils
{
  /// <summary>
  /// Class that contains simple and common helper for delegates and events.
  /// </summary>
  public static class ReflectionHelper
  {
    #region Public Methods

    /// <summary>
    /// Confirms the existence of a property on an object.
    /// </summary>
    /// <typeparam name="T">The type of the object to set.</typeparam>
    /// <param name="instance">The object to look for a property on.</param>
    /// <param name="name">The name of the property to look for.</param>
    /// <returns><c>true</c> if exists; otherwise <c>false</c></returns>
    public static bool PropertyExists<T>(T instance, string name)
    {
      if (instance == null)
        throw new ArgumentNullException("instance");

      PropertyInfo info = GetPropertyInfo(instance.GetType(), name, true);
      return info != null;
    }

    /// <summary>
    /// Confirms the existence of a property on an object.
    /// </summary>
    /// <param name="type">The type to look for a property on.</param>
    /// <param name="name">The name of the property to look for.</param>
    /// <returns><c>true</c> if exists; otherwise <c>false</c></returns>
    public static bool PropertyExists(Type type, string name)
    {
      PropertyInfo info = GetPropertyInfo(type, name, true);
      return info != null;
    }

    /// <summary>
    /// Sets the value of an object property.
    /// </summary>
    /// <param name="instance">The object to set the property of.</param>
    /// <param name="name">The name of the property to set.</param>
    /// <param name="value">The value to set on the property.</param>
    /// <exception cref="System.ArgumentNullException">The value or name parameter is null.</exception>
    /// <exception cref="System.ArgumentException">The name specified is invalid and either does not exist or is read only.</exception>
    public static void SetProperty(object instance, string name, object value)
    {
      ISynchronizeInvoke invoker = instance as ISynchronizeInvoke;

      if (invoker != null && invoker.InvokeRequired)
      {
        invoker.BeginInvoke(new ActionHandler<object, string, object>(SetProperty), new object[] { instance, name, value });
        return;
      }

      if (instance == null)
        throw new ArgumentNullException("instance");

      PropertyInfo info = GetPropertyInfo(instance.GetType(), name);

      if (!info.CanWrite)
        throw new InvalidOperationException(" The property " + name + " has not been set");

      info.SetValue(instance, value, null);
    }

    /// <summary>
    /// Sets the value of an object property.
    /// </summary>
    /// <param name="type">The static type to set the property of.</param>
    /// <param name="name">The name of the property to set.</param>
    /// <param name="value">The value to set on the property.</param>
    /// <exception cref="System.ArgumentNullException">The staticType or name parameter is null.</exception>
    /// <exception cref="System.ArgumentException">The name specified is invalid and either does not exist or is read only.</exception>
    public static void SetProperty(Type type, string name, object value)
    {
      if (type == null)
        throw new ArgumentNullException("type");

      PropertyInfo info = GetPropertyInfo(type, name);

      if (!info.CanWrite)
        throw new InvalidOperationException("The property " + name + " has not been set");

      info.SetValue(null, value, null);
    }

    /// <summary>
    /// Gets the value of an object property.
    /// </summary>
    /// <param name="instance">The object to get the property of.</param>
    /// <param name="name">The name of the property to get.</param>
    /// <returns>The value of the property, or null.</returns>
    /// <exception cref="System.ArgumentNullException">The value or name parameter is null.</exception>
    /// <exception cref="System.ArgumentException">The name specified is invalid.</exception>
    /// <returns>The property value.</returns>
    public static object GetProperty(object instance, string name)
    {
      ISynchronizeInvoke invoker = instance as ISynchronizeInvoke;

      if (invoker != null && invoker.InvokeRequired)
        return invoker.Invoke(new FuncHandler<object, string, object>(GetProperty), new object[] { instance, name });

      if (instance == null)
        throw new ArgumentNullException("instance");

      PropertyInfo info = GetPropertyInfo(instance.GetType(), name);

      if (!info.CanRead)
        throw new InvalidOperationException(name);

      return info.GetValue(instance, null);
    }

    /// <summary>
    /// Gets the value of an object property.
    /// </summary>
    /// <param name="type">The static type to get the property of.</param>
    /// <param name="name">The name of the property to get.</param>
    /// <returns>The value of the property, or null.</returns>
    /// <exception cref="System.ArgumentNullException">The staticType or name parameter is null.</exception>
    /// <exception cref="System.ArgumentException">The name specified is invalid.</exception>
    /// <returns>The property value.</returns>
    public static object GetProperty(Type type, string name)
    {
      if (type == null)
        throw new ArgumentNullException("type");

      PropertyInfo info = GetPropertyInfo(type, name);

      if (!info.CanRead)
        throw new InvalidOperationException(name);

      return info.GetValue(null, null);
    }

    /// <summary>
    /// Searches recursively through an object tree for property information.
    /// </summary>
    /// <param name="instance">The object to get the property from.</param>
    /// <param name="name">The name of the property to search for.</param>
    /// <returns>A PropertyInfo object for analyzing the property data.</returns>
    /// <exception cref="System.ArgumentNullException">The type or name parameter is null.</exception>
    /// <exception cref="System.ArgumentException">The name specified is invalid.</exception>
    /// <returns>The property info.</returns>
    public static PropertyInfo GetPropertyInfo(object instance, string name)
    {
      if (instance == null)
        throw new ArgumentNullException("instance");

      return GetPropertyInfo(instance.GetType(), name);
    }

    /// <summary>
    /// Searches recursively through an object tree for property information.
    /// </summary>
    /// <param name="type">The type of the object to get the property from.</param>
    /// <param name="name">The name of the property to search for.</param>
    /// <returns>A PropertyInfo object for analyzing the property data.</returns>
    /// <exception cref="System.ArgumentNullException">The type or name parameter is null.</exception>
    /// <exception cref="System.ArgumentException">The name specified is invalid.</exception>
    /// <returns>The property info.</returns>
    public static PropertyInfo GetPropertyInfo(Type type, string name)
    {
      return GetPropertyInfo(type, name, false);
    }

    /// <summary>
    /// Searches recursively through an object tree for property information.
    /// </summary>
    /// <param name="type">The type of the object to get the property from.</param>
    /// <param name="name">The name of the property to search for.</param>
    /// <param name="suppressExceptions">Specifies that exceptions for invalid fields should be suppressed.</param>
    /// <returns>A PropertyInfo object for analyzing the property data.</returns>
    /// <exception cref="System.ArgumentNullException">The type or name parameter is null.</exception>
    /// <exception cref="System.ArgumentException">The name specified is invalid.</exception>
    /// <returns>The property info.</returns>
    public static PropertyInfo GetPropertyInfo(Type type, string name, bool suppressExceptions)
    {
      if (type == null)
        throw new ArgumentNullException("type");

      if (string.IsNullOrEmpty(name))
        throw new ArgumentNullException("name");

      PropertyInfo info = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static);

      if (info == null)
      {
        if (type.BaseType != null)
        {
          info = GetPropertyInfo(type.BaseType, name, suppressExceptions);
        }
        else if (!suppressExceptions)
        {
          throw new ArgumentException(name);
        }
      }

      return info;
    }

    /// <summary>
    /// Invokes a method on an object.
    /// </summary>
    /// <param name="instance">The object to execute the method from.</param>
    /// <param name="name">The name of the method to execute.</param>
    /// <exception cref="System.ArgumentException">The name of the method provided is invalid.</exception>
    /// <exception cref="System.ArgumentNullException">The staticType argument is null or the name argument is null or empty.</exception>
    public static void InvokeMethod(object instance, string name)
    {
      InvokeMethod(instance, name, null);
    }

    /// <summary>
    /// Invokes a method on an object.
    /// </summary>
    /// <typeparam name="T">The type of the return value from the method.</typeparam>
    /// <param name="instance">The object to execute the method from.</param>
    /// <param name="name">The name of the method to execute.</param>
    /// <returns>The return value of the method, or null.</returns>
    /// <exception cref="System.ArgumentException">The name of the method provided is invalid.</exception>
    /// <exception cref="System.ArgumentNullException">The staticType argument is null or the name argument is null or empty.</exception>
    public static T InvokeMethod<T>(object instance, string name)
    {
      return InvokeMethod<T>(instance, name, null);
    }

    /// <summary>
    /// Invokes a method on an object.
    /// </summary>
    /// <param name="instance">The object to execute the method from.</param>
    /// <param name="name">The name of the method to execute.</param>
    /// <param name="parameters">Parameters required to execute the method.</param>
    /// <exception cref="System.ArgumentException">The name of the method provided is invalid.</exception>
    /// <exception cref="System.ArgumentNullException">The staticType argument is null or the name argument is null or empty.</exception>
    public static void InvokeMethod(object instance, string name, params object[] parameters)
    {
      ISynchronizeInvoke invoker = instance as ISynchronizeInvoke;

      if (invoker != null && invoker.InvokeRequired)
      {
        invoker.BeginInvoke(new ActionHandler<object, string, object[]>(InvokeMethod), new object[] { instance, name, parameters });
        return;
      }

      Type[] parameterTypes = ConstructParameterTypes(parameters);

      if (instance == null)
        throw new ArgumentNullException("instance");

      if (string.IsNullOrEmpty(name))
        throw new ArgumentNullException("name");

      MethodInfo info = GetMethodInfo(instance.GetType(), name, parameterTypes);
      info.Invoke(instance, parameters);
    }

    /// <summary>
    /// Invokes a method on an object.
    /// </summary>
    /// <typeparam name="T">The return value type.</typeparam>
    /// <param name="instance">The object to execute the method from.</param>
    /// <param name="name">The name of the method to execute.</param>
    /// <param name="parameters">Parameters required to execute the method.</param>
    /// <returns>The return value of the method, or null.</returns>
    /// <exception cref="System.ArgumentException">The name of the method provided is invalid.</exception>
    /// <exception cref="System.ArgumentNullException">The staticType argument is null or the name argument is null or empty.</exception>
    public static T InvokeMethod<T>(object instance, string name, params object[] parameters)
    {
      ISynchronizeInvoke invoker = instance as ISynchronizeInvoke;

      if (invoker != null && invoker.InvokeRequired)
        return (T)invoker.Invoke(new FuncHandler<object, string, object[], T>(InvokeMethod<T>), new object[] { instance, name, parameters });

      Type[] parameterTypes = ConstructParameterTypes(parameters);

      if (instance == null)
        throw new ArgumentNullException("instance");

      if (string.IsNullOrEmpty(name))
        throw new ArgumentNullException("name");

      MethodInfo info = GetMethodInfo(instance.GetType(), name, parameterTypes);
      return (T)info.Invoke(instance, parameters);
    }

    /// <summary>
    /// Invokes a method on an object.
    /// </summary>
    /// <param name="type">The type of the class to execute the method from.</param>
    /// <param name="name">The name of the method to execute.</param>
    /// <exception cref="System.ArgumentException">The name of the method provided is invalid.</exception>
    /// <exception cref="System.ArgumentNullException">The staticType argument is null or the name argument is null or empty.</exception>
    public static void InvokeMethod(Type type, string name)
    {
      InvokeMethod(type, name, null);
    }

    /// <summary>
    /// Invokes a method on an object.
    /// </summary>
    /// <typeparam name="T">The type of the method return value.</typeparam>
    /// <param name="type">The type of the class to execute the method from.</param>
    /// <param name="name">The name of the method to execute.</param>
    /// <returns>The return value of the method, or null.</returns>
    /// <exception cref="System.ArgumentException">The name of the method provided is invalid.</exception>
    /// <exception cref="System.ArgumentNullException">The staticType argument is null or the name argument is null or empty.</exception>
    public static T InvokeMethod<T>(Type type, string name)
    {
      return InvokeMethod<T>(type, name, null);
    }

    /// <summary>
    /// Invokes a method on an object.
    /// </summary>
    /// <param name="type">The type of the class to execute the method from.</param>
    /// <param name="name">The name of the method to execute.</param>
    /// <param name="parameters">Parameters required to execute the method.</param>
    /// <exception cref="System.ArgumentException">The name of the method provided is invalid.</exception>
    /// <exception cref="System.ArgumentNullException">The staticType argument is null or the name argument is null or empty.</exception>
    public static void InvokeMethod(Type type, string name, params object[] parameters)
    {
      Type[] parameterTypes = ConstructParameterTypes(parameters);

      if (type == null)
        throw new ArgumentNullException("type");

      if (string.IsNullOrEmpty(name))
        throw new ArgumentNullException("name");

      MethodInfo info = GetMethodInfo(type, name, parameterTypes);
      info.Invoke(null, parameters);
    }

    /// <summary>
    /// Invokes a method on an object.
    /// </summary>
    /// <typeparam name="T">The type of the method return value.</typeparam>
    /// <param name="type">The type of the class to execute the method from.</param>
    /// <param name="name">The name of the method to execute.</param>
    /// <param name="parameters">Parameters required to execute the method.</param>
    /// <returns>The return value of the method, or null.</returns>
    /// <exception cref="System.ArgumentException">The name of the method provided is invalid.</exception>
    /// <exception cref="System.ArgumentNullException">The staticType argument is null or the name argument is null or empty.</exception>
    public static T InvokeMethod<T>(Type type, string name, params object[] parameters)
    {
      Type[] parameterTypes = ConstructParameterTypes(parameters);

      if (type == null)
        throw new ArgumentNullException("type");

      if (string.IsNullOrEmpty(name))
        throw new ArgumentNullException("name");

      MethodInfo info = GetMethodInfo(type, name, parameterTypes);
      return (T)info.Invoke(null, parameters);
    }

    /// <summary>
    /// Safely raises an event.
    /// </summary>
    /// <typeparam name="T">The event handlers type (delegate).</typeparam>
    /// <param name="handlers">The event handlers.</param>
    /// <param name="args">The event arguments.</param>
    public static void RaiseEventSafely<T>(T handlers, params object[] args) where T : class
    {
      if (handlers == null)
        return;

      if (!typeof(T).IsSubclassOf(typeof(Delegate)))
        throw new InvalidOperationException(typeof(T).Name);

      Delegate delegateHandlers = handlers as Delegate;

      foreach (Delegate callback in delegateHandlers.GetInvocationList())
      {
        ISynchronizeInvoke invoker = callback.Target as ISynchronizeInvoke;

        if (invoker != null && invoker.InvokeRequired)
          invoker.BeginInvoke(delegateHandlers, args);
        else
          callback.DynamicInvoke(args);
      }
    }

    /// <summary>
    /// Adds a handler to an object event.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target object.</typeparam>
    /// <typeparam name="THandler">The type of the handler delegate.</typeparam>
    /// <param name="obj">The object.</param>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="handler">The han5dler delegate.</param>
    public static void AddEventHandler<TTarget, THandler>(TTarget obj, string eventName, THandler handler)
      where TTarget : class
      where THandler : class
    {
      if (obj == null)
        throw new ArgumentNullException("object");

      if (string.IsNullOrEmpty(eventName))
        throw new ArgumentNullException("eventName");

      if (handler == null || !handler.GetType().IsSubclassOf(typeof(Delegate)))
        throw new InvalidOperationException("The argument is not a delegate");

      EventInfo info = obj.GetType().GetEvent(eventName);

      if (info == null)
        throw new InvalidOperationException("Event not found " + eventName);

      info.AddEventHandler(obj, handler as Delegate);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Obtains a default method parameter type set.
    /// </summary>
    /// <param name="methodParameters">The method parameters to build the type set from.</param>
    /// <returns>An array of types to represent the types of the parameters passed into the method.</returns>
    private static Type[] ConstructParameterTypes(object[] methodParameters)
    {
      Type[] parameterTypes = null;

      if (methodParameters.Length > 0)
      {
        parameterTypes = new Type[methodParameters.Length];

        for (int i = 0; i < methodParameters.Length; ++i)
          parameterTypes[i] = methodParameters[i].GetType();
      }

      return parameterTypes;
    }

    /// <summary>
    /// Searches recursively through an object tree for method information.
    /// </summary>
    /// <param name="type">The type of the object to get the method from.</param>
    /// <param name="name">The name of the method to search for.</param>
    /// <param name="parameterTypes">An array of type arguments for method parameters.</param>
    /// <returns>A MethodInfo object for analyzing the method data.</returns>
    /// <exception cref="System.ArgumentException">The name of the method provided is invalid.</exception>
    /// <exception cref="System.ArgumentNullException">The staticType argument is null or the methodName argument is null or empty.</exception>
    /// <returns>The method info.</returns>
    private static MethodInfo GetMethodInfo(Type type, string name, Type[] parameterTypes)
    {
      MethodInfo info = null;
      ParameterInfo[] parameters = null;
      MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static);

      foreach (MethodInfo method in methods)
      {
        if (method.Name != name || method.IsGenericMethod)
          continue;

        parameters = method.GetParameters();

        if (parameters.Length == parameterTypes.Length)
        {
          bool found = true;

          for (int i = 0; i < parameters.Length; i++)
          {
            if (parameters[i].ParameterType != parameterTypes[i])
            {
              found = false;
              break;
            }
          }

          if (found)
          {
            info = method;
            break;
          }
        }
      }

      if (info == null)
      {
        if (type.BaseType != null)
          info = GetMethodInfo(type.BaseType, name, parameterTypes);
        else
          throw new ArgumentException(name);
      }

      return info;
    }

    #endregion
  }
}
