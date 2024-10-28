﻿using LigChat.Backend.Domain.DTOs.FlowDto;
using Microsoft.AspNetCore.Mvc;

namespace LigChat.Data.Interfaces.IControllers
{
    public interface IFlowControllerInterface
    {
        /// <summary>
        /// Retrieves all flows for a specific user and folder.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="folderId">The ID of the folder that contains the flows.</param>
        /// <returns>An IActionResult containing the status and data of all flows.</returns>
        IActionResult GetAll(int userId, int folderId);

        /// <summary>
        /// Retrieves a specific flow by its ID.
        /// </summary>
        /// <param name="id">The ID of the flow to retrieve.</param>
        /// <returns>An IActionResult containing the status and data of the specified flow.</returns>
        IActionResult GetById(string id);

        /// <summary>
        /// Creates a new flow based on the provided CreateFlowRequestDTO.
        /// </summary>
        /// <param name="flow">The data for the new flow.</param>
        /// <returns>An IActionResult indicating the status of the creation operation.</returns>
        IActionResult Save(CreateFlowRequestDTO flow);

        /// <summary>
        /// Updates an existing flow with the specified ID using the provided UpdateFlowRequestDTO.
        /// </summary>
        /// <param name="id">The ID of the flow to update.</param>
        /// <param name="flow">The updated data for the flow.</param>
        /// <returns>An IActionResult indicating the status of the update operation.</returns>
        IActionResult Update(string id, UpdateFlowRequestDTO flow);

        /// <summary>
        /// Deletes a flow based on its ID.
        /// </summary>
        /// <param name="id">The ID of the flow to delete.</param>
        /// <returns>An IActionResult indicating the status of the deletion operation.</returns>
        IActionResult Delete(string id);
    }
}