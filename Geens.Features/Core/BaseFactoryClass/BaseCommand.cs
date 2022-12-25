using Geens.Features.Core.BaseFactoryClass.Enums;
using MediatR;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Geens.Features.Core.BaseFactoryClass
{
    public abstract class BaseCommand<K> : IRequest<K>
    {
        public TypeDeRequette Operation { get; set; }
    }
}
