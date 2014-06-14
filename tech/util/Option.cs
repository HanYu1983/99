// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;


public interface IOption<ObjType>{
	ObjType Instance{ get; }
	
	IOption<ObjType> Map(Func<ObjType, Void> fun);
	
	IOption<TargetType> FlatMap <TargetType> (Func<ObjType, IOption<TargetType>> fun);
	
	ObjType Or(ObjType def);
	
	bool IsDeleted{get;}
}

public interface IIDObjContainer<ObjType>{
	ObjType GetObject(string id);
}

public abstract class AbstractOption<ObjType> : IOption<ObjType>{
	public abstract ObjType Instance{ get; }
	public IOption<ObjType> Map(Func<ObjType, Void> fun){
		if( !IsDeleted )
			fun(Instance);
		return this;
	}
	public IOption<TargetType> FlatMap <TargetType> (Func<ObjType, IOption<TargetType>> fun){
		return IsDeleted ? new Option<TargetType>(null, "") : fun(Instance);
	}
	
	public abstract ObjType Or(ObjType def);
	
	public abstract bool IsDeleted{ get; }
}

public class Option<ObjType> : AbstractOption<ObjType>
{
	string _value;
	public IIDObjContainer<ObjType> _container;

	public Option(IIDObjContainer<ObjType> container, string value)
	{
		_container = container;
		_value = value;
	}

	public override ObjType Instance{ 
		get{
			if(IsDeleted)
				throw new Exception("Option attempt to get null obj ["+_value+"]");
			return _container.GetObject(_value);
		}
	}

	public override ObjType Or(ObjType def){
		return IsDeleted ? def : _container.GetObject(_value);
	}
	
	public override bool IsDeleted{ get{ return _container == null ? true : _container.GetObject(_value) == null; } }

	public static Option<ObjType> Wrap(string obj, IIDObjContainer<ObjType> container){
		return new Option<ObjType>(container, obj);
	}

	public static Option<ObjType> None = new Option<ObjType>(null, "");
}