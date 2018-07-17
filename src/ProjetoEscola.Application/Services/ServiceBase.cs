using System;
using System.Collections.Generic;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interfaces.Repositories;
using ProjetoEscola.Domain.Interfaces.Services;
using ProjetoEscola.Domain.ValueObjects;

namespace ProjetoEscola.Domain.Services
{
	public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : EntityBase
	{
		protected readonly IRepositorioLeituraBase<TEntity> _LeituraRepository;
		protected readonly IRepositorioEscritaBase<TEntity> _EscritaRepository;

		public ServiceBase(IRepositorioLeituraBase<TEntity> leituraRepository, IRepositorioEscritaBase<TEntity> escritaRepository)
		{
			_LeituraRepository = leituraRepository;
			_EscritaRepository = escritaRepository;
		}

		public virtual TEntity Add(TEntity obj)
		{
			obj = ValidateToSave(obj);

			if (obj.ResultValidation.IsValid)
				_EscritaRepository.Add(obj);

			return obj;
		}

		public virtual TEntity Update(TEntity obj)
		{
			obj = ValidateToSave(obj);

			if (obj.ResultValidation.IsValid)
				_EscritaRepository.Update(obj);

			return obj;
		}

		public virtual TEntity ValidateToSave(TEntity obj)
		{
			obj.ResultValidation = new ValidationResult();
			return obj;
		}

		public virtual ValidationResult Remove(TEntity obj)
		{
			var resultValidation = ValidateToDelete(obj);

			if (resultValidation.IsValid)
			{
				try
				{
					_EscritaRepository.Remove(obj);
				}
				catch (Exception ex)
				{
					if (resultValidation == null)
						resultValidation = new ValidationResult();
					resultValidation.AdicionarErro(new ValidationError(ex.Message));
				}
			}
			return resultValidation;
		}

		public virtual ValidationResult ValidateToDelete(TEntity obj)
		{
			obj.ResultValidation = new ValidationResult();
			return obj.ResultValidation;
		}

		public void Dispose()
		{
			_EscritaRepository.Dispose();
			_LeituraRepository.Dispose();
		}
	}
}
