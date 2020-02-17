namespace TaganiPlus.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Entities.DTOs.WebResponses;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.WebUtilities;
    using Services.Interfaces;

    [Route("api/regions")]
    [ApiController]
    public class PhilippineRegionController : ControllerBase
    {
        private readonly IPhilippineRegionService regionService;
        private readonly IMapper mapper;

        public PhilippineRegionController(IPhilippineRegionService regionService, IMapper mapper)
        {
            this.regionService = regionService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("get-regions")]
        public async Task<IActionResult> GetRegionsAsync()
        {
            try
            {
                var result = this.mapper.Map<ICollection<RegionsWebResponse>>(await this.regionService.GetRegionsAsync());
                var response = this.mapper.Map<BaseResponse<ICollection<RegionsWebResponse>>>(result);
                response.StatusCode = StatusCodes.Status200OK;
                response.StatusName = ReasonPhrases.GetReasonPhrase(response.StatusCode);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("get-provinces")]
        public async Task<IActionResult> GetProvincesAsync()
        {
            try
            {
                var result = this.mapper.Map<ICollection<ProvincesWebResponse>>(await this.regionService.GetProvincesAsync());
                var response = this.mapper.Map<BaseResponse<ICollection<ProvincesWebResponse>>>(result);
                response.StatusCode = StatusCodes.Status200OK;
                response.StatusName = ReasonPhrases.GetReasonPhrase(response.StatusCode);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("get-municipalities")]
        public async Task<IActionResult> GetMunicipalitiesAsync()
        {
            try
            {
                var result = this.mapper.Map<ICollection<MunicipalitiesWebResponse>>(await this.regionService.GetMunicipalitiesAsync());
                var response = this.mapper.Map<BaseResponse<ICollection<MunicipalitiesWebResponse>>>(result);
                response.StatusCode = StatusCodes.Status200OK;
                response.StatusName = ReasonPhrases.GetReasonPhrase(response.StatusCode);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("get-barangays")]
        public async Task<IActionResult> GetBarangaysAsync()
        {
            try
            {
                var result = this.mapper.Map<ICollection<BarangaysWebResponse>>(await this.regionService.GetBarangaysAsync());
                var response = this.mapper.Map<BaseResponse<ICollection<BarangaysWebResponse>>>(result);
                response.StatusCode = StatusCodes.Status200OK;
                response.StatusName = ReasonPhrases.GetReasonPhrase(response.StatusCode);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
