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
	int Identity{ get; }

	ObjType Instance{ get; }
	
	IOption<ObjType> Map(Action<ObjType> fun);
	
	IOption<TargetType> FlatMap <TargetType> (Func<ObjType, IOption<TargetType>> fun);
	
	ObjType Or(ObjType def);
	
	bool IsDeleted{get;}
}

public interface IOptionContainer{
	object GetObject(int id);
}

public abstract class AbstractOption<ObjType> : IOption<ObjType>{
	public abstract ObjType Instance{ get; }
	public IOption<ObjType> Map(Action<ObjType> fun){
		if( !IsDeleted )
			fun(Instance);
		return this;
	}
	public IOption<TargetType> FlatMap <TargetType> (Func<ObjType, IOption<TargetType>> fun){
		return IsDeleted ? new Option<TargetType>(null, -1) : fun(Instance);
	}
	
	public abstract ObjType Or(ObjType def);
	
	public abstract bool IsDeleted{ get; }

	public abstract int Identity{ get; }
}

public class Option<ObjType> : AbstractOption<ObjType>
{
	int _value;
	public IOptionContainer _container;

	public Option(IOptionContainer container, int value)
	{
		_container = container;
		_value = value;
	}

	public override int Identity{ get{ return _value; } }

	public override ObjType Instance{ 
		get{
			if(IsDeleted)
				throw new Exception("Option attempt to get null obj ["+_value+"]");
			return (ObjType)_container.GetObject(_value);
		}
	}

	public override ObjType Or(ObjType def){
		return IsDeleted ? def : (ObjType)_container.GetObject(_value);
	}
	
	public override bool IsDeleted{ get{ return _container == null ? true : _container.GetObject(_value) == null; } }

	public static Option<ObjType> Wrap(int id, IOptionContainer container){
		return new Option<ObjType>(container, id);
	}

	public static Option<ObjType> None = new Option<ObjType>(null, -1);
}

public class NullOption<ObjType> : AbstractOption<ObjType>{
	ObjType _obj;
	public NullOption(ObjType obj){
		_obj = obj;
	}
	public override ObjType Instance{ get{ return _obj; } }
	public override ObjType Or(ObjType def){
		return _obj == null ? def : _obj;
	}
	public override bool IsDeleted{ get{ return _obj == null; } }
	public override int Identity{ get{ return -1; } }
}


